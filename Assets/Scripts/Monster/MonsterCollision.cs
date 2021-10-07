using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    public GameObject healthBar;

    private HealthSystem healthSystem;

    private float time;
    float targetMoveSpeed;

    private void Start()
    {
        healthSystem = healthBar.GetComponent<HealthSystem>();
        targetMoveSpeed = transform.parent.gameObject.GetComponent<Monster>().moveSpeed;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    private bool isPoison = false;
    private void OnTriggerEnter(Collider other)
    {
        GameObject targetObject = other.gameObject;
        string targetTag = targetObject.tag;

        // targetMoveSpeed = targetObject.transform.parent.gameObject.GetComponent<Monster>().moveSpeed;


        if (targetTag.Equals("Bullet"))
        {
            //healthSystem.TakeDamage(targetObject.GetComponent<Bullet>().damage);
            healthSystem.TakeDamage(100f);
        }
        if (targetTag.Equals("Arrow"))
        {
            healthSystem.TakeDamage(20f);
        }
        if (targetTag.Equals("Skill"))
        {
            healthSystem.TakeDamage(targetObject.GetComponent<Skill>().damage);
        }
        if (targetTag.Equals("IceTower"))
        {
            transform.parent.gameObject.GetComponent<Monster>().moveSpeed = targetMoveSpeed/2f;
        }
        if(targetTag.Equals("PoisonTower"))
        {
            isPoison = true;
            StartCoroutine(DotDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject targetObject = other.gameObject;
        string targetTag = targetObject.tag;

        if (targetTag.Equals("IceTower"))
        {
            transform.parent.gameObject.GetComponent<Monster>().moveSpeed = targetMoveSpeed;
        }
        if (targetTag.Equals("PoisonTower"))
        {
            isPoison = false;
            Debug.Log("포이느타워 탈출!");
            StopCoroutine(DotDamage());
        }
    }
    IEnumerator DotDamage()
    {
        while (true)
        {
            if (!isPoison)
                break;
            yield return new WaitForSeconds(1.5f);
            healthSystem.TakeDamage(20);
        }
    }
}
