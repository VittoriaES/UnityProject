using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem {
    string Name { get; }

    string Description { get;}

    Sprite Image { get; }

    void onPickUp();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}

