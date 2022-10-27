using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Item
{
    public override void Act()
    {
        gameObject.SetActive(false);
    }

    public override void AdvanceState(int id)
    {
        return;
    }
}
