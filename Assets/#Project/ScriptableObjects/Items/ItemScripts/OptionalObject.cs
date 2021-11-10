using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Optional Object", menuName = "Inventory System/Items/Optional")]

public class OptionalObject : ItemObject
{
    public void Awake()
    {
       type = ItemType.Optional; 
    }
}
