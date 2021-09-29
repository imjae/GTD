using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    private Monster monster;
    private Transform monsterTransform;
    private GameObject healthBar;
    private HealthSystem healthSystem;
    private Vector3 spawnPosition;

    private Animator animator;

    // ���Ͱ� ������ ��(�θ��� �θ�ü �������� ������� ����)
    private GameObject currentMap;

    bool isFirstPower = true;
    bool isTouchStartTile = false;
    bool isDie = false;

    // ù���� ��������Ʈ ������� false�� ����Ǿ� LookAt ��ȿȭ ��Ű�� ����
    bool isFirstWayPoint = true;

    private Rigidbody tmpRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();
        monsterTransform = monster.transform;
        spawnPosition = monsterTransform.position;

        healthBar = transform.Find("Canvas").Find("HealthBar").gameObject;
        healthSystem = healthBar.GetComponent<HealthSystem>();
        animator = GetComponent<Animator>();

        tmpRigidBody = GetComponent<Rigidbody>();

        currentMap = transform.parent.parent.gameObject;
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
        {
            if(isTouchStartTile)
            {
                if (isFirstWayPoint)
                {

                    transform.LookAt(currentMap.GetComponent<Level1Map>().wayPoint[0].transform);
                    animator.SetTrigger("RunTrigger");
                    isFirstWayPoint = false;
                }
                monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
            }
            else
            {
                if(isFirstPower)
                {
                    Vector3 horizontalVector = new Vector3(-1f, 0.3f, Random.Range(-0.2f, 0.2f));
                    float power = Random.Range(20.0f, 25.0f);
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
        this.isTouchStartTile = !this.isTouchStartTile;
    }

    public void MonsterDestroy()
    {
        Destroy(gameObject);
    }
}