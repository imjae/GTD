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

    // 몬스터가 생성된 맵(부모의 부모객체 가져오는 방식으로 구현)
    private GameObject currentMap;

    bool isFirstPower = true;
    bool isTouchStartTile = false;
    bool isDie = false;

    // 첫번쨰 웨이포인트 찍고나서 false로 변경되어 LookAt 무효화 시키는 변수
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
        // 체력이 0이하이고, Die 플래그 false(안죽음) 일 경우만 실행
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
        // 죽지 않았음 플래그
        if(!isDie)
        {
            // 첫번째 타일 밟음 플래그
            if(isTouchStartTile)
            {
                // 첫번째 웨이포인트 찍었는지에 대한 플래그
                if (isFirstWayPoint)
                {
                    transform.LookAt(currentMap.GetComponent<Level1Map>().wayPoint[0].transform);
                    isFirstWayPoint = false;
                }
                monsterTransform.Translate(Vector3.forward * monster.moveSpeed);
            }
            // 첫번째 타일 밟기 전 로직
            else
            {
                // 튕겨졌는지에 대한 플래그
                if(isFirstPower)
                {
                    // 가로 튕기는 방향 벡터 구하기위해 랜덤값 설정
                    Vector3 horizontalVector = new Vector3(-1f, 0.3f, Random.Range(-0.3f, 0.3f));
                    // 튕기는 힘 랜덤 조정
                    float power = Random.Range(20f, 23f);

                    // horizontalVector 방향백터 계산 후 튕기는 힘 추가
                    tmpRigidBody.velocity = horizontalVector.normalized * power;

                    isFirstPower = false;
                }
            }
        }
            
    }

    void triggerTouchStartTile()
    {
        animator.SetTrigger("WalkTrigger");
        // 처음 시작 타일을 밟았다는 표시
        this.isTouchStartTile = true;
    }

    public void MonsterDestroy()
    {
        Destroy(gameObject);
    }
}
