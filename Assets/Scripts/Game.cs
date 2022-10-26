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
        var objectBeingLookedAt = player.getObjectBeingLookedAt();
        if (objectBeingLookedAt != null)
        {
            ui.togglePointer(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked the item");
            }
        }
        else
        {
            ui.togglePointer(false);
        }
    }
}
