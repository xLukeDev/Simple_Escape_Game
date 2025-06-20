using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform target;
    public float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float fireTimer;
    public float bulletSpeed;

    


    private void Awake()
    {

        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(FollowTarget());
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Fire();
            fireTimer = 0f;
        }
    }


    private IEnumerator FollowTarget()
    {

        while (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                break;
            }

            yield return null;
        }
        
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled)
        {
            Agent.SetDestination(target.transform.position);
            yield return Wait;
        }


    }

    private void Fire()
    {
        if(bulletPrefab == null || firePoint == null) return;

        Vector3 direction = (target.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        var enemybullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        enemybullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
    }
    


}
