using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Necessary,
    Optional
}
public abstract class ItemObject : ScriptableObject
{
    public Sprite icon;

    public Sprite zoomedIcon;
    public ItemType type;

    public string itemName;

    public string displayName;

    [TextArea(20, 20)]
    public string description;

}
