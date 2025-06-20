using UnityEngine;
using UnityEngine.UI;

using Button = UnityEngine.UI.Button;
public class chestButttonHandler : MonoBehaviour
{
    public GameObject chestPanel;
    public CollectableItems item;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onChestButtonClick);
    }

    void onChestButtonClick()
    {
        InventoryManager.Inventory.AddItem(item);
        chestPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
