using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private UiManager ui;
    [SerializeField] private Inventory inventory;

    private List<Item> _inventory = new List<Item>();
    private bool _isPaused = false;

    // Update is called once per frame
    private void Update()
    {
        if (_isPaused)
        {
            if (!Input.GetMouseButtonDown(0)) return;
            ContinueGame();
        }

        player.MoveAndLook();
        CheckForInteractableObjects();
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
    
    private void EnableInteractionState(IInteractable objectBeingLookedAt)
    {
        ui.TogglePointer(true);
        if (Input.GetMouseButtonDown(0))
        {
            RespondToInteractableObject(objectBeingLookedAt);
            if (objectBeingLookedAt.getAttributes().canPickUp)
            {
                inventory.AddItem(objectBeingLookedAt.getItem());
            }
        }
        objectBeingLookedAt.Act();
    }

    private void RespondToInteractableObject(IInteractable objectBeingLookedAt)
    {
        var itemAttributes = objectBeingLookedAt.getAttributes(); 
        CheckIfTextProvided(itemAttributes);
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

    // private bool CheckIfItemCombinationExists(List<Interaction> interactions, ItemAttributes currentItem)
    // {
    //     var interactionMap =
    //         interactions.ToDictionary(interaction => interaction.item, interaction => interaction.response);
    //
    //     if (!interactionMap.ContainsKey(currentItem)) return false;
    //     EnableTextDisplay(interactionMap[currentItem]);
    //     return true;
    // }

    private void PickUpItem(ItemAttributes item)
    {
        
        
    }
}
