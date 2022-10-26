using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Item
{
    public new void Act()
    {
        Destroy(this);
    }
}
