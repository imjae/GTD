using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    private Monster monster;
    private Transform monsterTransform;
    private GameObject healthBar;
    private HealthSystem healthSystem;

    private Animator animator;

    bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();
        monsterTransform = monster.transform;
        healthBar = transform.Find("Canvas").Find("HealthBar").gameObject;
        healthSystem = healthBar.GetComponent<HealthSystem>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSystem.hitPoint <= 0 && isDie == false)
        {
            isDie = true;
            animator.SetTrigger("DieTrigger");
            GameManager.Instance.currentGold += monster.dropGold;
            GameManager.Instance.currentMonsterCount--;
        }
    }

    private void FixedUpdate()
    {
        if(!isDie)
            monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
        {
            if(isTouchStartTile)
            {
                if (isFirstWayPoint)
                {

                    transform.LookAt(currentMap.GetComponent<Level1Map>().wayPoint[0].transform);
                    isFirstWayPoint = false;
                }
                monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
            }
            else
            {
                if(isFirstPower)
                {
                    Vector3 horizontalVector = new Vector3(-1f, 0.3f, Random.Range(-0.3f, 0.3f));
                    float power = Random.Range(20f, 23f);
                    tmpRigidBody.velocity = horizontalVector.normalized * power;
                    //tmpRigidBody.AddForce(a.normalized * 1600f);
                    isFirstPower = false;
                }
            }
        }
            
    }

    void triggerTouchStartTile()
    {
        animator.SetTrigger("WalkTrigger");
        // ó�� ���� Ÿ���� ��Ҵٴ� ǥ��
        this.isTouchStartTile = true;
    }

    public void MonsterDestroy()
    {

        Destroy(gameObject);
    }
}
