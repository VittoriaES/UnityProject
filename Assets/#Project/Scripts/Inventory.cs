using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemData[] inventory;

    int index = 0;

    private void Update() {
        if (Input.GetKeyDown("space"))
        {
            NextItemInfo();
        }
    }

    public void NextItemInfo()
    {
        if (index > inventory.Length)
        {
            index = 0;
        }

        Debug.Log("Item name: " + inventory[index].itemName);
        Debug.Log("Item name: " + inventory[index].ItemDescription);

        switch(inventory[index].itemType)
        {
            case ItemType.Necessary:
            Debug.Log("Item type: Necessary");
            break;

            case ItemType.Optional:
            Debug.Log("Item type: Optional");
            break;
        }

        index ++;
    }
}
