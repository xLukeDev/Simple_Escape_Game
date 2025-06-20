using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject craftingPanel;
    public GameObject InventoryPanel;
    public GameObject questsPanel;
    public GameObject menuPanel;

    [Header("PlayerMovement")]
    public PlayerMovement playerMovement;

    
    
    
    private bool _craftingActive = false;
    private bool _inventoryActive = false;
    private bool _questsActive = false;
    

    [Header(("PROGRESS TRACKER"))] public Transform progressPanel;
    public TextMeshProUGUI messageField;
    public int currentStage;
    public List<string> messages = new List<string>();
    public GameObject pickaxe;
    public bool chestOpened = false;
    public GameObject nextLevel;
    public bool berriesCollected = false;
    public bool crystalsCollected = false;
    public bool bmushroomCollected = false;
    public bool pmushroomCollected = false;
    public bool stickCollected = false;
    public bool potionCrafted = false;
    public bool crystalCrafted = false;
    public CollectableItems potion;
    public CollectableItems weapon;
    public CollectableItems crystal;
    public GameObject Portal;
    public GameObject PortalTrigger;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        
    }
    
    private void Start()
    {
        AddMessage();
    }
    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleQuests();
            AddMessage();
        }
        
        CheckCrafted();
        CheckPortal();
        
    }

    private void CheckCrafted()
    {
        if (InventoryManager.Inventory.HasItem(potion, 1) && !potionCrafted)
        {
            currentStage++;
            potionCrafted = true;
        }
        if (InventoryManager.Inventory.HasItem(crystal, 1) && !crystalCrafted)
        {
            currentStage++;
            crystalCrafted = true;
        }
    }

    private void CheckPortal()
    {
        if (currentStage == 9)
        {
            Portal.SetActive(true);
            PortalTrigger.SetActive(true);
        }
    }

    public void ToggleCrafting()
    {
        _craftingActive = !_craftingActive;

        craftingPanel.SetActive(_craftingActive);
        playerMovement.enabled = !_craftingActive;

        Cursor.visible = _craftingActive;
        Cursor.lockState = _craftingActive ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    void ToggleInventory()
    {
        _inventoryActive = !_inventoryActive;

        InventoryPanel.SetActive(_inventoryActive);
        playerMovement.enabled = !_inventoryActive;

        Cursor.visible = _inventoryActive;
        Cursor.lockState = _inventoryActive ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    void ToggleQuests()
    {
        _questsActive = !_questsActive;

        questsPanel.SetActive(_questsActive);
        playerMovement.enabled = !_questsActive;

        Cursor.visible = _questsActive;
        Cursor.lockState = _questsActive ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    public void AddMessage()
    {
        messageField.text = messages[currentStage];
    }
}