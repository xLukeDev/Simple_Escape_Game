using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class CraftingSystem : MonoBehaviour
{

    public GameObject IngredientItem;
    public Transform contentParent;
    public GameObject craftingIcon;
    public GameObject craftingButton;

    public InventoryManager InventoryManager;

    [Header("List of Recipes")] public List<CraftingRecipes> allRecipes;

    private CraftingRecipes currentRecipe;

    private void Start()
    {
        craftingButton.GetComponent<Button>().onClick.AddListener(onCraftingButtonClicked);
    }

    public void craftingShowItems(CraftingRecipes recipe)
    {
        clearCraftingItems();

        showCraftingIcon(recipe);
        addCraftingItem(recipe.itemA);
        addCraftingItem(recipe.itemB);
        
        gameObject.SetActive(true);
    }

    public void addCraftingItem(CollectableItems item)
    {
        GameObject newItem = Instantiate(IngredientItem, contentParent);
        newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.invIcon;
        newItem.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.itemName;
    }

    public void clearCraftingItems()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void showCraftingIcon(CraftingRecipes recipe)
    {
        Image iconImage = craftingIcon.GetComponent<Image>();
        iconImage.sprite = recipe.outputItem.invIcon;
        Color iconColor = iconImage.color;
        iconColor.a = 1f;
        iconImage.color = iconColor;
    }

    public CraftingRecipes FindRecipeByIcon()
    {
        Sprite craftingSprite = craftingIcon.GetComponent<Image>().sprite;
        CraftingRecipes foundrecipe = allRecipes.Find(recipe => recipe.outputItem.invIcon == craftingSprite);
        return foundrecipe;
    }

    private void onCraftingButtonClicked()
    {
        currentRecipe = FindRecipeByIcon();
        if (currentRecipe != null)
        {

            if (InventoryManager.Inventory.HasItem(currentRecipe.itemA, 1) &&
                InventoryManager.Inventory.HasItem(currentRecipe.itemB, 1))
            {
                InventoryManager.Inventory.RemoveItem(currentRecipe.itemA);
                InventoryManager.Inventory.RemoveItem(currentRecipe.itemB);
                
                InventoryManager.Inventory.AddItem(currentRecipe.outputItem);
                
                Debug.Log("Swtorzyles/as item: " + currentRecipe.outputItem.itemName);
            }
            else
            {
                Debug.Log("Nie masz tyle itemow");
            }
        }
        else
        {
            Debug.Log("Nie znaleziono ikony");
        }
            
    }
    
    


}
