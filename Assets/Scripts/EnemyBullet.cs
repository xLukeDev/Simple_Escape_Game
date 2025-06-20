using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float life = 5f;
    public GameObject itemDrop;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthManager.HM.TakeDamage(20);
            AudioManager.AM.PlayDamageSound();
            Debug.Log("Damaged");
            Destroy(gameObject);
        }
        
    }


}
