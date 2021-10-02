using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;
    // 보스 출연 연출 끝남을 알리는 플래그
    public bool isFInishBossMovie = false;
    // 보스가 공격할 타겟 표시 이펙트
    public GameObject targetEffect;


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
    }

    public IEnumerator AttackTower()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            GameObject[] currentBuildedTowerArr = GameManager.Instance.GetBuiledTowerArr();
            Debug.Log(currentBuildedTowerArr.Length);
            int randomAttackTowerCount = 0;
            int[] selectedTowerIndexArr = new int[1];
            if (currentBuildedTowerArr.Length != 0)
            {
                randomAttackTowerCount = (int)Random.Range(1, (currentBuildedTowerArr.Length + 1) / 2);
                selectedTowerIndexArr = GameManager.Instance.GetRandomInt(randomAttackTowerCount, 0, (currentBuildedTowerArr.Length - 1));

                Debug.Log(selectedTowerIndexArr.Length + "개 공격!");

                for(int i=0; i < selectedTowerIndexArr.Length; i++)
                {
                    // 공격할 타워 랜덤 선책
                    Vector3 targetPosition = currentBuildedTowerArr[selectedTowerIndexArr[i]].transform.position;
                    Debug.Log(targetPosition);
                    Instantiate(targetEffect, new Vector3(targetPosition.x, targetPosition.y + 5f, targetPosition.z), Quaternion.Euler(-90f, 0f, 0f));
                }
            }
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
