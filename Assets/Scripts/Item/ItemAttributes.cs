using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemAttributes", order = 1)]
public class ItemAttributes : ScriptableObject
{
    public Sprite image;
    public int id;
    public List<Interaction> interactions;
    public string examineMessage;
    public bool canPickUp;
}
