using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{

    public Image icon;
    public TMP_Text amountText;
    public GameObject amountField;

    private CollectableItems item;
    private int amount;

    public void Start()
    {
        if (isEmpty())
        {
            amountField.SetActive(false);
            Color tempColor = this.icon.color;
            tempColor.a = 0f;
            this.icon.color = tempColor;
        }
    }

    public void setItem(CollectableItems newItem)
    {
        item = newItem;
        amount = 1;
        icon.sprite = newItem.invIcon;
        amountText.text = amount.ToString();
        amountField.SetActive(true);
        Color tempColor = this.icon.color;
        tempColor.a = 1f;
        this.icon.color = tempColor;


    }

    public void addAmount(int value)
    {
        amount += value;
        amountText.text = amount.ToString();
    }

    public bool isEmpty() => item == null;
    public CollectableItems GetItem() => item;
    
    public int GetAmount() => amount;

    public void removeAmount(int value)
    {
        amount -= value;
        if (amount <= 0)
        {
            clearSlot();
        }
        else
        {
            amountText.text = amount.ToString();
        }
    }

    public void clearSlot()
    {
        item = null;
        amount = 0;
        icon.sprite = null; 
        amountField.SetActive(false);
        Color tempColor = this.icon.color;
        tempColor.a = 0f;
        this.icon.color = tempColor;
    }

}
