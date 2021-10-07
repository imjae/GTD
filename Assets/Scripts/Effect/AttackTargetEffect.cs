using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetEffect : MonoBehaviour
{
    // ����Ʈ ���� �ð�
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
        // �ѹ��� �����ϵ��� �ϴ� �÷���
        bool isLoof = true;
        while(isLoof)
        {
            isLoof = false;
            // ����ũ ����Ʈ ����
            GameObject cloneSpark = Instantiate(sparkEffect, new Vector3(initPosition.x, initPosition.y + 10f, initPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Destroy(cloneSpark);

            GameObject cloneExplosion = Instantiate(explosionEffect, initPosition, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
