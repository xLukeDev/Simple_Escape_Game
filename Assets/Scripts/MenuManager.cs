using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    private bool _menuActive = false;
    private PlayerMovement playerMovement;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }
    
    void ToggleMenu()
    {
        
        if (playerMovement == null)
            playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement == null) return;
        
        _menuActive = !_menuActive;
        
        menuPanel.SetActive(_menuActive);
        playerMovement.enabled = !_menuActive;
        
        Cursor.visible = _menuActive;
        Cursor.lockState = _menuActive ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
