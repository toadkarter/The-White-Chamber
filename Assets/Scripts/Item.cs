using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemResponse itemResponse = null;

    public ItemResponse Act()
    {
        return itemResponse;
    }
}
