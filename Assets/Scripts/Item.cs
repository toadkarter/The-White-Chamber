using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemAttributes attributes;
    public void Act()
    {
        return;
    }

    public ItemAttributes getAttributes()
    {
        return attributes;
    }
}
