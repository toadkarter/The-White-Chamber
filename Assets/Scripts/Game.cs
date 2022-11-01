using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private UiManager ui;
    [SerializeField] private Inventory inventory;
    [SerializeField] private LightPuzzle puzzle;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private int delay = 8;
    private bool _isPaused = false;
    private bool _onWinningPath = false;

    private void Start()
    {
        StartCoroutine(ShowTitle(delay));
    }

    private void Update()
    {
        if (_isPaused)
        {
            if (!Input.GetMouseButtonDown(0)) return;
            ContinueGame();
        }
        player.MoveAndLook();
        CheckForInteractableObjects();
        CycleThroughInventory();
        puzzle.PlayPuzzle();
    }

    private void CheckForInteractableObjects()
    {
        var objectBeingLookedAt = player.GetObjectBeingLookedAt();
        if (objectBeingLookedAt != null)
        {
            EnableInteractionState(objectBeingLookedAt);
        }
        else
        {
            ui.TogglePointer(false);
        }
    }

    private void ContinueGame()
    {
        _isPaused = false;
        player.SetCanMove(true);
        ui.SetCursorIsVisible(true);
        ui.ToggleTextPanel(false);
        ui.ClearText();
    }
    
    private void EnableInteractionState(Item objectBeingLookedAt)
    {
        ui.TogglePointer(true);
        if (!Input.GetMouseButtonDown(0)) return;
        RespondToInteractableObject(objectBeingLookedAt);
        objectBeingLookedAt.Act();
    }

    private void CheckIfCanPickUp(Item objectBeingLookedAt)
    {
        if (!objectBeingLookedAt.getAttributes().canPickUp) return;
        inventory.AddItem(objectBeingLookedAt.getItem());
        ui.SetInventoryImage(objectBeingLookedAt.getAttributes().image);
    }

    private void RespondToInteractableObject(Item item)
    {
        var itemAttributes = item.getAttributes();
        if (itemAttributes == null) return;

        PlayWinCutsceneIfWon(item);
        
        CheckIfTextProvided(itemAttributes);
        CheckIfCanPickUp(item);
        
        if (!inventory.NothingSelected())
        {
            CheckIfItemCombinationExists(item, inventory.GetSelectedItem());
        }
    }

    private void PlayWinCutsceneIfWon(Item item)
    {
        if (_onWinningPath && item.getAttributes().id == 10)
        {
            SceneManager.LoadScene(1);
        }
    }

    private bool CheckIfTextProvided(ItemAttributes itemAttributes)
    {
        if (itemAttributes.examineMessage == null) return false;
        EnableTextDisplay(itemAttributes.examineMessage);
        _isPaused = true;
        return true;
    }

    private void EnableTextDisplay(string text)
    {
        player.SetCanMove(false);
        ui.SetCursorIsVisible(false);
        ui.ToggleTextPanel(true);
        ui.DisplayText(text);
    }

    private void CycleThroughInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetNextItem();
            if (inventory.GetSelectedItem() == null) return;
            ui.SetInventoryImage(inventory.GetSelectedItem().getAttributes().image);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.SetPreviousItem();
            if (inventory.GetSelectedItem() == null) return;
            ui.SetInventoryImage(inventory.GetSelectedItem().getAttributes().image);
        }
    }

    private bool CheckIfItemCombinationExists(Item currentItem, Item inventoryItem)
    {
        var currentAttributes = currentItem.getAttributes();
        var interactionMap =
            currentAttributes.interactions.ToDictionary(interaction => interaction.itemId, interaction => interaction.response);
        
        if (!interactionMap.ContainsKey(inventoryItem.getAttributes().id)) return false;
        EnableTextDisplay(interactionMap[inventoryItem.getAttributes().id]);
        currentItem.AdvanceState(inventoryItem.getAttributes().id);

        CheckIfOnWinningPath(currentItem, inventoryItem);
        
        _isPaused = true;
        return true;
    }

    private void CheckIfOnWinningPath(Item currentItem, Item inventoryItem)
    {
        if (inventoryItem.getAttributes().id == 3 && currentItem.getAttributes().id == 6)
        {
            Debug.Log("Setting win path");
            _onWinningPath = true;
        }
    }

    private IEnumerator ShowTitle(int delay)
    {
        yield return new WaitForSeconds(delay);
        title.gameObject.SetActive(false);
        yield return null;
    }
}
