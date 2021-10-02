using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetEffect : MonoBehaviour
{
    float effectTime = 0.0f;
    public GameObject sparkEffect;
    public GameObject explosionEffect;

    private Vector3 initPosition;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        StartCoroutine(ReadyExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        effectTime += Time.deltaTime;
    }

    void FixedUpdate()
    {

    }

    IEnumerator ReadyExplosion()
    {
        bool isLoof = true;
        while(isLoof)
        {
            isLoof = false;
            GameObject cloneSpark = Instantiate(sparkEffect, new Vector3(initPosition.x, initPosition.y + 10f, initPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Destroy(cloneSpark);
            GameObject cloneExplosion = Instantiate(explosionEffect, initPosition, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
