using UnityEngine;

public abstract class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemAttributes attributes;
    public void Act()
    {
        return;
    }

    public Item getItem()
    {
        return this;
    }

    public ItemAttributes getAttributes()
    {
        return attributes;
    }
}
