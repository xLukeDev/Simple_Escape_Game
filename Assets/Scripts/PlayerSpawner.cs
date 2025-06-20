using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Start()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
    }
}
