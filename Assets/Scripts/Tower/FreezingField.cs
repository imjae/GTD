using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingField : MonoBehaviour
{

    public GameObject StartPoint;
    public GameObject FreezeEffect;
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
            var freeze = Instantiate(FreezeEffect, StartPoint.transform.position, StartPoint.transform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(freeze.gameObject);
        }
    }
   }