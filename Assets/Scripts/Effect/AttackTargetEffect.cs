using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetEffect : MonoBehaviour
{
    // 이팩트 생성 시간
    float effectTime = 0.0f;
    public GameObject sparkEffect;
    public GameObject explosionEffect;

    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
        StartCoroutine(ReadyExplosion());
    }

    void FixedUpdate()
    {
        effectTime += Time.deltaTime;
    }

    IEnumerator ReadyExplosion()
    {
        // 한번만 실행하도록 하는 플래그
        bool isLoof = true;
        while(isLoof)
        {
            isLoof = false;
            // 스파크 이팩트 생성
            GameObject cloneSpark = Instantiate(sparkEffect, new Vector3(initPosition.x, initPosition.y + 10f, initPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Destroy(cloneSpark);

            GameObject cloneExplosion = Instantiate(explosionEffect, initPosition, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
