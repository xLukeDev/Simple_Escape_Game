using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RecipeButtonHandler : MonoBehaviour
{

    public CraftingRecipes assignedRecipe;
    public CraftingSystem craftingUI;
    
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick);
    }

    void onClick()
    {
        Debug.Log("kliknieto przycisk");
        if (assignedRecipe != null && craftingUI != null)
        {
            craftingUI.craftingShowItems(assignedRecipe);
        }
    }
}
