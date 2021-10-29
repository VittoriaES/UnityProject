using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "InventorySystem")]
public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public string ItemDescription;
}

public enum ItemType { Necessary, Optional}
