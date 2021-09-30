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
        float playTime = GameManager.Instance.playTime;
        GameObject targetObject = other.gameObject;
        string targetTag = targetObject.tag;

        if (targetTag.Equals("Bullet"))
        {
            healthSystem.TakeDamage(1000);
        }
        else if (targetTag.Equals("Arrow"))
        {

        }
        else if (targetTag.Equals("TriggerBox"))
        {
            if (playTime % 1f == 0)
            {
                healthSystem.TakeDamage(10);
            }

        }
        else if (targetTag.Equals("IceTriggerBox")) ;
        {
            //if(Time.timeScale==1.0f)
            //{
            //    Time.timeScale = 0.5f;
            //}

            gameObject.GetComponent<Monster>().moveSpeed = 0.1f;
        }
    }

}
