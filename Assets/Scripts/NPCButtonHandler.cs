using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class NPCButtonHandler : MonoBehaviour
{
    public GameObject panel;
    private void onNPCButtonClcik()
    {
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onNPCButtonClcik);
    }
}
