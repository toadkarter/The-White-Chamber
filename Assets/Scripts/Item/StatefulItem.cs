using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulItem : Item
{
    [SerializeField] private List<ItemAttributes> states;
    private int currentState = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        SetAttributes(states[currentState]);
    }

    public override void Act()
    {
        return;
    }

    public override void AdvanceState(int id)
    {
        if (currentState + 1 >= states.Count && !getAttributes().stateAdvancerIds.Contains(id)) return;
        currentState++;
        SetAttributes(states[currentState]);
    }
}
