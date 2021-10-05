using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSmoke: MonoBehaviour
{

    public GameObject startPoint;
    public GameObject poisonEffect;
    ParticleSystem[] poisonParticleArr = new ParticleSystem[3];

    // 생성된 이펙트 담는 변수
    GameObject poison;
    // 범위 안에 몬스터 있을때 true
    bool isTargeting = false;
    void Start()
    {
        poison = Instantiate(poisonEffect, startPoint.transform.position, startPoint.transform.rotation);
        for (int i = 0; i < poisonParticleArr.Length; i++)
        {
            poisonParticleArr[i] = poison.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
            poisonParticleArr[i].Stop();
        }
        poison.SetActive(true);
    }


    bool isOnFirst = true;
    bool isOffFirst = true;
    private void FixedUpdate()
    {
        PoisonEffcetOn(transform.position, 16f);
        if (isTargeting && isOnFirst)
        {
            isOnFirst = false;
            isOffFirst = true;
            PoisonParticleOn();
        } else if(!isTargeting && isOffFirst)
        {
            isOffFirst = false;
            isOnFirst = true;
            PoisonParticleOff();
        }
    }


    void PoisonParticleOn()
    {
        foreach (ParticleSystem ps in poisonParticleArr)
        {
            ps.Play();
        }
    }

    void PoisonParticleOff()
    {
        foreach (ParticleSystem ps in poisonParticleArr)
        {
            ps.Stop();
        }
    }

    void PoisonEffcetOn(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int monsterCount = 0;

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Monster"))
                monsterCount++;
        }

        if (monsterCount > 0)
        {
            isTargeting = true;
        }
        else
        {
            isTargeting = false;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        isAttack = false;

    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            if (!isAttack)
                StartCoroutine(PoisonEffcetOn());
        }
    }*/

    /*IEnumerator AttackMonster()
    {
        isAttack = true;
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            if (!isAttack)
            {
                break;
            }
            var poison = Instantiate(poisonEffect, startPoint.transform.position, startPoint.transform.rotation);
            yield return new WaitForSeconds(4f);
            Destroy(poison.gameObject);
        }
    }*/
}