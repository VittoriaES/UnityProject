using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewController : MonoBehaviour
{
    public InventoryObject inventory;
    public Transform inventoryViewParent;
    public GameObject itemViewPrefab;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    public GameObject itemGO = null;

    // Start is called before the first frame update
    void Start()
    {
        // foreach (var item in inventory.Container)
        // {
        //     var itemGO = GameObject.Instantiate(itemViewPrefab, inventoryViewParent);
        //     itemGO.GetComponent<ItemView>().InitItem(item);
        // }
    }

    void Update()
    {
       
    }

    // Update is called once per frame
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var itemGO = GameObject.Instantiate(itemViewPrefab, inventoryViewParent);
            itemGO.GetComponent<ItemView>().InitItem(inventory.Container[i]);
            itemsDisplayed.Add(inventory.Container[i], itemGO);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
       {
           if(!itemsDisplayed.ContainsKey(inventory.Container[i]))
           {
                var itemGO = GameObject.Instantiate(itemViewPrefab, inventoryViewParent);
                itemGO.GetComponent<ItemView>().InitItem(inventory.Container[i]);
                itemsDisplayed.Add(inventory.Container[i], itemGO);
           }
       } 
    }

    // public void UpdateDisplay()
    // {
    //     for (int i = 0; i< inventory.Container.Count; i++)
    //     {
    //         var itemGO = GameObject.Instantiate(itemViewPrefab, inventoryViewParent);
    //         itemGO.GetComponent<ItemView>().InitItem(inventory.Container[i]);
    //     }
    // }
}
