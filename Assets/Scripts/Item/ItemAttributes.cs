using System.Collections.Generic;
using UnityEngine;

// Source: https://docs.unity3d.com/Manual/class-ScriptableObject.html
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemAttributes", order = 1)]
public class ItemAttributes : ScriptableObject
{
    public Sprite image;
    public int id;
    public List<Interaction> interactions;
    public string examineMessage;
    public bool canPickUp;
    public List<int> stateAdvancerIds;
}
