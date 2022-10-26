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
    void Update()
    {
        var objectBeingLookedAt = player.getObjectBeingLookedAt();
        Debug.Log(objectBeingLookedAt);
        ui.togglePointer(objectBeingLookedAt != null);
    }
}
