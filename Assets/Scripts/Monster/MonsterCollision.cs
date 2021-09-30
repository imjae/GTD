using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    public GameObject healthBar;

    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = healthBar.GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject targetObject = other.gameObject;
        string targetTag = targetObject.tag;

        if (targetTag.Equals("Bullet"))
        {
            healthSystem.TakeDamage(1000);
        }
        else if (targetTag.Equals("Arrow"))
        {

        }
    }
}
