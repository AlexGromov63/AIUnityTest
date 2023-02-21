using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profile : MonoBehaviour
{
    public List<ItemData> inventory;

    public void AddItem(ItemData data) {
        if (inventory.Contains(data))
        {
            return;
        }
        else
        {
            inventory.Add(data);
        }
        
    }
    public bool isItemExists(ItemData data)
    {
        return inventory.Contains(data);
    }

    public void removeItemData(ItemData data)
    {
        if (isItemExists(data))
        {
            inventory.Remove(data);
        }
        else
        {
            Debug.Log("Item " + data.name + " does not exist");
        }
    }
}
