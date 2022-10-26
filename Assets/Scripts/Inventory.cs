using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly List<Item> _inventory = new List<Item>();
    private Item _selectedItem;

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _inventory.Remove(item);
    }

    public void SetNextItem()
    {
        if (IsEmpty()) return;
        int currentItemIndex = _inventory.IndexOf(_selectedItem);
        _selectedItem = currentItemIndex + 1 >= _inventory.Count ? _inventory[0] : _inventory[currentItemIndex + 1];
    }

    public void SetPreviousItem()
    {
        if (IsEmpty()) return;
        int currentItemIndex = _inventory.IndexOf(_selectedItem);
        _selectedItem = currentItemIndex - 1 > 0 ? _inventory[_inventory.Count - 1] : _inventory[currentItemIndex - 1];
    }

    public Item GetSelectedItem()
    {
        return IsEmpty() ? null : _selectedItem;
    }
    
    private bool IsEmpty()
    {
        return _inventory.Count == 0;
    }
}
