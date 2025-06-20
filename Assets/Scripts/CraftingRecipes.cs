using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crafting System", menuName = "Crafting System/Recipes", order = 2)]
public class CraftingRecipes : ScriptableObject
{

    public CollectableItems itemA;
    public CollectableItems itemB;
    public CollectableItems outputItem;
    public string description;

}
