using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{

    public Image itemIcon;

    private InventorySlot inventorySlotItem;

    public void InitItem (InventorySlot item)
    {
        this.inventorySlotItem = item;
        itemIcon.sprite = inventorySlotItem.item.icon;

    }
}
