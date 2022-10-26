using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemAttributes", order = 1)]
public class ItemAttributes : ScriptableObject
{
    public List<Interaction> interactions;
    public string examineMessage;
    public bool canPickUp;
}
