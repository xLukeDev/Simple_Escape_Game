using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speed = 2f;
    public float height = 2f;
    public bool startFromTop = true; //true: startuje z góry

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = startFromTop ? 0f : height;
        float pingPong = Mathf.PingPong(Time.time * speed, height);
        float newY = startPos.y + (startFromTop ? -pingPong : pingPong);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.AM.PlayDamageSound();
            HealthManager.HM.TakeDamage(30);
        }
    }

}
