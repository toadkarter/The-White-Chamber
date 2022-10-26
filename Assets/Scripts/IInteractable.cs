using UnityEngine;

public interface IInteractable
{
    void Act();
    ItemAttributes getAttributes();
    Item getItem();
}
