using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform contentParent;
    [SerializeField]
    private List<InventoryObject> inventoryObjects = new List<InventoryObject>();

    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Inventory>();
            }
            return instance;
        }
    }

    public void AddObject(int count, InventoryObject inventoryObject)
    {
        var isAdded = false;

        for (int i = 0; i < inventoryObjects.Count; i++)
        {
            if (inventoryObjects[i].TagObject == inventoryObject.TagObject && !inventoryObjects[i].IsFilled)
            {
                inventoryObjects[i].AddObject(count);
                isAdded = true;
                return;
            }
        }

        if (!isAdded)
        {
            var newInventoryObject = Instantiate(inventoryObject);
            newInventoryObject.transform.parent = contentParent;
            newInventoryObject.ResetCount();
            newInventoryObject.AddObject(count);
            inventoryObjects.Add(newInventoryObject);
        }
    }

    public bool CheckAndDecreaseObject(InventoryObjectTag objectTag)
    {
        for (int i = 0; i < inventoryObjects.Count; i++)
        {
            if (inventoryObjects[i].TagObject == objectTag)
            {
                inventoryObjects[i].Decrease();
                return true;
            }
        }

        return false;
    }

    public void RemoveObject(InventoryObject inventoryObject)
    {
        for (int i = 0; i < inventoryObjects.Count; i++)
        {
            if (inventoryObjects[i] == inventoryObject)
            {
                inventoryObjects.Remove(inventoryObject);
            }
        }
    }
}
