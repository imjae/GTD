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

    // ù���� ��������Ʈ ����� false�� ����Ǿ� LookAt ��ȿȭ ��Ű�� ����
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
        // ü���� 0�����̰�, Die �÷��� false(������) �� ��츸 ����
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
        // ���� �ʾ��� �÷���
        if(!isDie)
        {
            // ù��° Ÿ�� ���� �÷���
            if(isTouchStartTile)
            {
                // ù��° ��������Ʈ ��������� ���� �÷���
                if (isFirstWayPoint)
                {
                    transform.LookAt(currentMap.GetComponent<Level1Map>().wayPoint[0].transform);
                    isFirstWayPoint = false;
                }
                monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
            }
            // ù��° Ÿ�� ��� �� ����
            else
            {
                // ƨ���������� ���� �÷���
                if(isFirstPower)
                {
                    // ���� ƨ��� ���� ���� ���ϱ����� ������ ����
                    Vector3 horizontalVector = new Vector3(-1f, 0.3f, Random.Range(-0.3f, 0.3f));
                    // ƨ��� �� ���� ����
                    float power = Random.Range(20f, 23f);

                    // horizontalVector ������� ��� �� ƨ��� �� �߰�
                    tmpRigidBody.velocity = horizontalVector.normalized * power;

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
