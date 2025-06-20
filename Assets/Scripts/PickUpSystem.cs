using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PickUpSystem : MonoBehaviour
{

    private ItemInstance nearbyItem;
    // Update is called once per frame
    void Update()
    {

        if (nearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            if (nearbyItem.item.gameState <= GameManager.Instance.currentStage)
            {
                InventoryManager.Inventory.AddItem(nearbyItem.item);
                
                

                if (nearbyItem.item.itemName == "brazowy grzyb" && !GameManager.Instance.bmushroomCollected)
                {
                    GameManager.Instance.currentStage++;
                    GameManager.Instance.bmushroomCollected = true;
                }
                
                else if (nearbyItem.item.itemName == "fioletowy grzyb" && !GameManager.Instance.pmushroomCollected)
                {
                    GameManager.Instance.currentStage++;
                    GameManager.Instance.pmushroomCollected = true;
                }
                else if (nearbyItem.item.itemName == "patyk" && !GameManager.Instance.stickCollected)
                {
                    GameManager.Instance.currentStage++;
                    GameManager.Instance.stickCollected = true;
                }
                
                AudioManager.AM.PlayPickupSound();
                Destroy(nearbyItem.gameObject);
                Debug.Log($"Zebrano: {nearbyItem.item.itemName}");
                nearbyItem = null;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            var instance = other.GetComponent<ItemInstance>();
            if (instance != null)
            {
                nearbyItem = instance;
                Debug.Log($"Podejdź do: {nearbyItem.item.itemName}, wciśnij E aby zebrać");
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            if (other.GetComponent<ItemInstance>() == nearbyItem)
            {
                nearbyItem = null;
                Debug.Log("Oddalono się od przedmiotu");
            }
        }
    }
    
    
}
