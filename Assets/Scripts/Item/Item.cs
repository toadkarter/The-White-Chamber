using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ItemAttributes attributes;
    public abstract void Act();

    public Item getItem()
    {
        return this;
    }

    public ItemAttributes getAttributes()
    {
        return attributes;
    }

    public override int GetHashCode()
    {
        return attributes.id;
    }
    protected void SetAttributes(ItemAttributes attribute)
    {
        this.attributes = attribute;
    }

    public abstract void AdvanceState(int id);
}
