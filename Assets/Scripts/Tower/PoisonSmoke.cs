using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSmoke: MonoBehaviour
{

    public GameObject StartPoint;
    public GameObject PoisonEffect;
    bool isAttack = false;
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
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            if (!isAttack)
            {
                break;
            }
            var poison = Instantiate(PoisonEffect, StartPoint.transform.position, StartPoint.transform.rotation);
            yield return new WaitForSeconds(4f);
            Destroy(poison.gameObject);
        }
    }
}