using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCrystal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinLose.WL.Win();
        }
    }
}
