using System.Collections;
using UnityEngine;


public class InteractWithObject : MonoBehaviour
{
    public string type;
    public bool isPlayerNearby = false;
    public CollectableItems item;

    public Animator animAnimator;
    public GameObject UIPanel1;
    public GameObject UIPanel2;

    private void Update()
    {
        
        if(!isPlayerNearby || !Input.GetKeyDown(KeyCode.E)) return;

        switch (type)
        {
            case "crafting" : GameManager.Instance.ToggleCrafting(); break;
            case "jagodki" : InteractBlueberries(); break;
            case "krysztalki" : InteractCrystals(); break;
            case "skrzynka" : InteractChest(); break;
            case "janek" : InteractNPC(); break;
            
        }
    }

    private void InteractBlueberries()
    {
        if (GameManager.Instance.currentStage == 4)
        {
            foreach (Transform child in transform)
            {
                if (child.name.Contains("JAGODA"))
                {
                    Destroy(child.gameObject);
                    InventoryManager.Inventory.AddItem(item);
                }
            }
        
            if (InventoryManager.Inventory.HasItem(item, 30) && !GameManager.Instance.berriesCollected)
            {
                GameManager.Instance.currentStage++;
                GameManager.Instance.berriesCollected = true;
            }
            
        }
    }

    private void InteractCrystals()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("krysztal"))
            {
                GameManager.Instance.pickaxe.SetActive(true);
                animAnimator.SetTrigger("PlayAnim");
                Destroy(child.gameObject);
                InventoryManager.Inventory.AddItem(item);
            }
        }
        if (InventoryManager.Inventory.HasItem(item, 10) && !GameManager.Instance.crystalsCollected)
        {
            GameManager.Instance.currentStage++;
            GameManager.Instance.crystalsCollected = true;
        }
    }

    private void InteractChest()
    {
        if (!GameManager.Instance.chestOpened && GameManager.Instance.currentStage == 3)
        {
            Debug.Log("Mozesz otworzyc skrzynke");
            animAnimator.SetTrigger("openChest");
            StartCoroutine(WaitForUI(UIPanel1));
            GameManager.Instance.chestOpened = true;
            GameManager.Instance.currentStage++;
        }
    }

    private void InteractNPC()
    {
        if (GameManager.Instance.currentStage == 5)
        {
            StartCoroutine(WaitForUI(UIPanel1));
            GameManager.Instance.currentStage++;
        }
        else if (GameManager.Instance.currentStage == 7)
        {
            StartCoroutine(WaitForUI(UIPanel2));
            GameManager.Instance.nextLevel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log($"Podejdź do obiektu, wciśnij E");
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Oddalono się od obiektu");
        }
        
    }

    IEnumerator WaitForUI(GameObject panel)
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
