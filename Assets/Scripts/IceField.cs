using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceField: MonoBehaviour
{

    public GameObject StartPoint;
    public GameObject IceEffect;
    public float attackSpeed;
    bool isAttack =false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Monster")
        {
            Debug.Log("Ãæµ¹");
            if (!isAttack)
                StartCoroutine(AttackMonster());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isAttack = false;
        
    }

    IEnumerator AttackMonster()
    {
        isAttack = true;
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            if (!isAttack) {
                break;
            }
            var ice = Instantiate(IceEffect, StartPoint.transform.position, StartPoint.transform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(ice.gameObject);
        }
    }
   }