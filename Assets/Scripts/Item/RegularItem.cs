using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularItem : Item
{
    public override void Act()
    {
        Debug.Log("Nothing happens");
    }

    public override void AdvanceState(int id)
    {
        Debug.Log("Nothing happens");
    }
}
