using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    public GameObject healthBar;
    private HealthSystem healthSystem;
    bool isPoison = false;

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

    private void OnTriggerStay(Collider other)
    {
        
        GameObject targetObject = other.gameObject;
        string targetTag = targetObject.tag;


        if (GameManager.Instance.playTime % 1f == 0)
        {
           
            if (targetTag.Equals("TriggerBox"))
            {
                healthSystem.TakeDamage(15);
                
            }
            else if(targetTag.Equals("IceTriggerBox"))
            {
                gameObject.transform.parent.gameObject.GetComponent<Monster>().moveSpeed = 0.1f;
            }
        }
        
    }
   
    


    private void OnTriggerExit(Collider other)
    {
        
        {
            if (!isPoison)
            {

                StartCoroutine(OnBuffCoroutine(6));
            }
        }
    }
    IEnumerator OnBuffCoroutine(int time)
    {

        isPoison = true;
        while (time > 0)
        {
            yield return new WaitForSeconds(3);
            healthSystem.TakeDamage(5);
            time--;
        }
        isPoison = false;
    }


}


