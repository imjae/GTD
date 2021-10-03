using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;
    // 보스 출연 연출 끝남을 알리는 플래그
    public bool isFInishBossMovie = false;
    // 보스가 움직여야하는 플래그
    public bool isMoving = false;
    // 보스가 공격할 타겟 표시 이펙트
    public GameObject targetEffect;
    // 보스 이동 경로 포인트
    public GameObject bossWaypoint1;
    public GameObject bossWaypoint2;
    public GameObject bossWaypoint3;
    public GameObject bossWaypoint4;
    // 보스가 어느 웨이포인트 향하고 있는지 담고있는 변수
    public string currentLookAtWaypoint = "";


    private GameObject level1Map;
    // 체력 바
    private GameObject bossHealthBar;

    // 보스가 처음 생성된 위치
    private Vector3 startPosition;
    // 보스가 처음 생성된 위치에서 이동할 위치
    private Vector3 startMovePosition = new Vector3(-0.32f, -7.65f, -0.69f);

    private float bossSurviveTime = 0.0f;

    void Start()
    {
        fireBreath.SetActive(false);
        bossHealthBar = GameObject.FindWithTag("MainCanvas").transform.Find("BossHealthBar").gameObject;
        StartCoroutine(AttackTower());
        StartCoroutine(MovePattern());
    }

    // Update is called once per frame
    void Update()
    {
        bossSurviveTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (bossSurviveTime <= 1.6f)
        {
            transform.Translate(Vector3.forward * 0.15f);
        }

        if(isMoving)
        {
            if (currentLookAtWaypoint.Equals("bossWaypoint1"))
            {
                transform.position = Vector3.Slerp(transform.position, bossWaypoint1.transform.position, Time.deltaTime);
            }
            else if(currentLookAtWaypoint.Equals("bossWaypoint2"))
            {
                transform.position = Vector3.Slerp(transform.position, bossWaypoint2.transform.position, Time.deltaTime);
            }
            else if (currentLookAtWaypoint.Equals("bossWaypoint3"))
            {
                transform.position = Vector3.Slerp(transform.position, bossWaypoint3.transform.position, Time.deltaTime);
            }
            else if (currentLookAtWaypoint.Equals("bossWaypoint4"))
            {
                transform.position = Vector3.Slerp(transform.position, bossWaypoint4.transform.position, Time.deltaTime);
            }
        }
    }

    public IEnumerator AttackTower()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            GameManager.Instance.RefreshBuiledTowerArr();
            GameObject[] currentBuildedTowerArr = GameManager.Instance.GetBuiledTowerArr();
            Debug.Log(currentBuildedTowerArr.Length);
            int randomAttackTowerCount = 0;
            int[] selectedTowerIndexArr = new int[1];
            if (currentBuildedTowerArr.Length != 0)
            {
                randomAttackTowerCount = (int)Random.Range(1, (currentBuildedTowerArr.Length + 1) / 2);
                selectedTowerIndexArr = GameManager.Instance.GetRandomInt(randomAttackTowerCount, 0, (currentBuildedTowerArr.Length - 1));

                for(int i=0; i < selectedTowerIndexArr.Length; i++)
                {
                    // 공격할 타워 랜덤 선책
                    Vector3 targetPosition = currentBuildedTowerArr[selectedTowerIndexArr[i]].transform.position;
                    Instantiate(targetEffect, new Vector3(targetPosition.x, targetPosition.y + 5f, targetPosition.z), Quaternion.Euler(-90f, 0f, 0f));
                }
            }
        }
    }

    public IEnumerator MovePattern()
    {
        //1 : 271.95f,  1008.9f,    -848.1f
        //2 : 316.6f,   1005.3f,    -893.19f
        //3 : 316.6f,   1004.7f,    -813.6f
        //4 : 375.7f,   1009.8f,    -848.1f
        while (true)
        {
            currentLookAtWaypoint = "bossWaypoint1";
            transform.LookAt(bossWaypoint1.transform);
            yield return new WaitForSeconds(8f);

            isMoving = true;
            yield return new WaitForSeconds(3f);
            isMoving = false;

            currentLookAtWaypoint = "bossWaypoint2";
            transform.LookAt(bossWaypoint2.transform);
            yield return new WaitForSeconds(5f);

            isMoving = true;
            yield return new WaitForSeconds(3f);
            isMoving = false;

            currentLookAtWaypoint = "bossWaypoint3";
            transform.LookAt(bossWaypoint3.transform);
            yield return new WaitForSeconds(5f);
            
            isMoving = true;
            yield return new WaitForSeconds(3f);
            isMoving = false;

            currentLookAtWaypoint = "bossWaypoint4";
            transform.LookAt(bossWaypoint4.transform);
            yield return new WaitForSeconds(5f);

            isMoving = true;
            yield return new WaitForSeconds(3f);
            isMoving = false;
        }
    }

    public void ActiveBreath()
    {
        fireBreath.SetActive(true);
    }

    public void UnActiveBreath()
    {
        fireBreath.SetActive(false);
    }

    public void ActiveBossHealthBar()
    {
        bossHealthBar.SetActive(true);
    }
    public void UnActiveBossHealthBar()
    {
        bossHealthBar.SetActive(false);
    }
}
