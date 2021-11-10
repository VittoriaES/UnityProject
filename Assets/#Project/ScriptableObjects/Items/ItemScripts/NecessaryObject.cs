using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Necessary Object", menuName = "Inventory System/Items/Necessary")]
public class NecessaryObject : ItemObject
{
    public void Awake()
    {
       type = ItemType.Necessary; 
    }
}
