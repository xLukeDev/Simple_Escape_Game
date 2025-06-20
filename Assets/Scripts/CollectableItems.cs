using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItems", menuName = "CollectableItemsData/Items", order = 1)]
public class CollectableItems : ScriptableObject
{
    public string itemName;
    public bool craftable;
    public bool eatable;
    public Sprite invIcon;
    public GameObject itemModel;
    public int gameState;
}
