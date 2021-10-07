using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingField : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject freezeEffect;
    ParticleSystem[] freezeParticleArr;

    public GameObject parent;

    // 생성된 이펙트 담는 변수
    GameObject freeze;
    // 범위 안에 몬스터 있을때 true
    bool isTargeting = false;
    void Start()
    {
        freezeParticleArr = new ParticleSystem[4];
        freeze = Instantiate(freezeEffect, startPoint.transform.position, startPoint.transform.rotation);
        freeze.transform.SetParent(parent.transform);
        int idx = 1;
        for(int i=0; i< freezeParticleArr.Length; i++ )
        {
            freezeParticleArr[i] = freeze.transform.GetChild(idx++).gameObject.GetComponent<ParticleSystem>();
            freezeParticleArr[i].Stop();
        }
        freeze.SetActive(true);
    }

    bool isOnFirst = true;
    bool isOffFirst = true;
    private void FixedUpdate()
    {
        IceEffcetOn(transform.position, 16f);
        if (isTargeting && isOnFirst)
        {
            isOnFirst = false;
            isOffFirst = true;
            IceParticleOn();
        }
        else if (!isTargeting && isOffFirst)
        {
            isOffFirst = false;
            isOnFirst = true;
            IceParticleOff();
        }
    }

    void IceParticleOn()
    {
        foreach (ParticleSystem ps in freezeParticleArr)
        {
            ps.Play();
        }
    }

    void IceParticleOff()
    {
        foreach (ParticleSystem ps in freezeParticleArr)
        {
            ps.Stop();
        }
    }

    void IceEffcetOn(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int monsterCount = 0;


        foreach(Collider col in hitColliders)
        {
            if (col.CompareTag("Monster"))
                monsterCount++;
        }

        if (monsterCount > 0)
        {
            isTargeting = true;
        } else
        {
            isTargeting = false;
        }
    }


    /*  private void OnTriggerEnter(Collider other)
      {
          if (other.tag == "Monster")
          {
              if (!isAttack)
                  StartCoroutine(AttackMonster());
          }
      }*/
    /*private void OnTriggerExit(Collider other)
    {
        isAttack = false;

    }*/

    /*IEnumerator AttackMonster()
    {
        isAttack = true;
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            if (!isAttack)
            {
                break;
            }
            freeze = Instantiate(freezeEffect, startPoint.transform.position, startPoint.transform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(freeze.gameObject);
        }
    }
*/
}