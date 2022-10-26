using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Movement player;
    [SerializeField] private UiManager ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        player.MoveAndLook();
        
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

    private void EnableInteractionState(IInteractable objectBeingLookedAt)
    {
        ui.TogglePointer(true);
        if (Input.GetMouseButtonDown(0))
        {
            RespondToInteractableObject(objectBeingLookedAt);
        }
    }

    private void RespondToInteractableObject(IInteractable objectBeingLookedAt)
    {
        var itemResponse = objectBeingLookedAt.Act();
        if (itemResponse.examineMessage != null)
        {
            player.SetCanMove(false);
            ui.SetCursorIsVisible(false);
            ui.ToggleTextPanel(true);
            ui.DisplayText(itemResponse.examineMessage);
            // player.SetCanMove(true);
            // ui.ToggleTextPanel(false);
            // ui.ClearText();
        }
    }
}
