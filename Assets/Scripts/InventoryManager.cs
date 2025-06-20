using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Inventory;

    [Header("Konfiguracja slota")] 
    public GameObject slot;

    public Transform slotParent;

    public List<SlotUI> slots = new List<SlotUI>();
    

    private void Awake()
    {
        if (Inventory == null)
        {
            Inventory = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        slots.Clear();
        foreach (Transform child in slotParent)
        {
            SlotUI slotUI = child.GetComponent<SlotUI>();
            if (slotUI != null)
            {
                slots.Add(slotUI);
            }
        }
        
        
    }

    public void AddItem(CollectableItems newItem)
    {
        foreach (SlotUI slot in slots)
        {
            if (!slot.isEmpty() && slot.GetItem() == newItem)
            {
                slot.addAmount(1);
                return;
            }
            
        }

        foreach (SlotUI slot in slots)
        {
            if (slot.isEmpty())
            {
                slot.setItem(newItem);
                return;


            }
        }
        
        Debug.Log("Nie mozna dodac itemu, ekwipunek jest pelny!");
    }
    
    public void RemoveItem(CollectableItems itemToRemove)
    {
        foreach (SlotUI slot in slots)
        {
            if (!slot.isEmpty() && slot.GetItem() == itemToRemove)
            {
                if (slot.GetAmount() > 1)
                {
                    slot.removeAmount(1);
                    Debug.Log("Usunięto 1 sztukę: " + itemToRemove.name);
                }
                else
                {
                    slot.clearSlot();
                    Debug.Log("Usunięto ostatnią sztukę: " + itemToRemove.name);
                }
                return;
            }
        }

        Debug.Log("Nie znaleziono przedmiotu w ekwipunku: " + itemToRemove.name);
    }
    
    public bool HasItem(CollectableItems item, int quantity)
    {
        int totalAmount = 0;

        foreach (SlotUI slot in slots)
        {
            if (!slot.isEmpty() && slot.GetItem() == item)
            {
                totalAmount += slot.GetAmount();
            }
        }

        return totalAmount >= quantity;
    }
    
}
