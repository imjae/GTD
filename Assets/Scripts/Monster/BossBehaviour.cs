using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;
    // ���� �⿬ ���� ������ �˸��� �÷���
    public bool isFInishBossMovie = false;
    // ������ ���������ϴ� �÷���
    public bool isMoving = false;
    // ������ ������ Ÿ�� ǥ�� ����Ʈ
    public GameObject targetEffect;
    // ���� �̵� ��� ����Ʈ
    public GameObject bossWaypoint1;
    public GameObject bossWaypoint2;
    public GameObject bossWaypoint3;
    public GameObject bossWaypoint4;

    // ������ ��� ��������Ʈ ���ϰ�(����) �ִ����� ����ִ� ����
    public string currentLookAtWaypoint = "";

    // ü�� ��
    private GameObject bossHealthBar;

    // ������ ó�� ������ ��ġ
    private Vector3 startPosition;
    // ������ ó�� ������ ��ġ���� �̵��� ��ġ
    private Vector3 startMovePosition = new Vector3(-0.32f, -7.65f, -0.69f);

    // ������ ���� �ð� ��� ����
    private float bossSurviveTime = 0.0f;

    // ���� �¸� �÷���
    private bool isClear = false;
    void Start()
    {
        // �ʱ⿡ �� �մ� ��� ����(���� �״� ����� �ִϸ��̼���Ʈ�ѷ� �̺�Ʈ���� ����)
        fireBreath.SetActive(false);
        bossHealthBar = transform.Find("Canvas").Find("HealthBar").gameObject;

        StartCoroutine(AttackTower());
        StartCoroutine(MovePattern());
    }

    // Update is called once per frame
    void Update()
    {
        bossSurviveTime += Time.deltaTime;

        if(bossHealthBar.GetComponent<HealthSystem>().hitPoint <= 0)
        {
            isClear = true;
            // ���� �¸�
            if(isClear)
            {
                isClear = false;
                SceneManager.LoadScene("GTD_clear");
            }
            
        }
    }

    private void FixedUpdate()
    {
        // ���� ���� ������ 1.6�� ������ �ൿ (������ �̵�)
        if (bossSurviveTime <= 1.6f)
        {
            transform.Translate(Vector3.forward * 0.15f);
        }

        // ������ ������ ���� �̵��ϴ� �÷���(isMoving)
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
            // 15�� ���� ������ Ÿ���� ����
            yield return new WaitForSeconds(15f);

            // ������ Ÿ���� ��� �迭�� ���� ���·� Refresh (�����ϱ� ���� �ѹ��� ȣ���ؾ���)
            GameManager.Instance.RefreshBuiledTowerArr();
            // ���� ������ Ÿ�� �迭
            GameObject[] currentBuildedTowerArr = GameManager.Instance.GetBuiledTowerArr();
            // Debug.Log(currentBuildedTowerArr.Length);

            // �������� ������ Ÿ�� ��
            int randomAttackTowerCount = 0;
            // ���� Ÿ���� ���õ� Ÿ���� �ε����� ��� Int�迭(������)
            int[] selectedTowerIndexArr = new int[1];

            if (currentBuildedTowerArr.Length != 0)
            {
                randomAttackTowerCount = (int)Random.Range(1, (currentBuildedTowerArr.Length + 1) / 2);
                selectedTowerIndexArr = GameManager.Instance.GetRandomInt(randomAttackTowerCount, 0, (currentBuildedTowerArr.Length - 1));

                for(int i=0; i < selectedTowerIndexArr.Length; i++)
                {
                    // ������ Ÿ�� ���� ����
                    Vector3 targetPosition = currentBuildedTowerArr[selectedTowerIndexArr[i]].transform.position;
                    // Ÿ�� ����Ʈ ��ü�� ����Ʈ ���� ��ũ��Ʈ���� Destroy() �ȴ�.
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
