using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private UiManager ui;
    [SerializeField] private Inventory inventory;
    [SerializeField] private LightPuzzle puzzle;
    private bool _isPaused = false;
    
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
        if (inventory.NothingSelected())
        {
            CheckIfTextProvided(itemAttributes);
            CheckIfCanPickUp(item);
        }
        else
        {
            CheckIfItemCombinationExists(itemAttributes.interactions, inventory.GetSelectedItem().getAttributes());
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

    private bool CheckIfItemCombinationExists(IEnumerable<Interaction> interactions, ItemAttributes currentItem)
    {
        var interactionMap =
            interactions.ToDictionary(interaction => interaction.itemId, interaction => interaction.response);
        
        if (!interactionMap.ContainsKey(currentItem.id)) return false;
        EnableTextDisplay(interactionMap[currentItem.id]);
        _isPaused = true;
        return true;
    }
}
