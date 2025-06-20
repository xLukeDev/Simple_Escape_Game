using System;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public CollectableItems item;
    private void Awake()
    {
        if (item != null)
        {
            name = item.itemName;
        }
    }
}