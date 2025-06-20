using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeAnimHandler : MonoBehaviour
{
    public void onPickaxeAnimFinished()
    {
        GameManager.Instance.pickaxe.SetActive(false);
    }
}
