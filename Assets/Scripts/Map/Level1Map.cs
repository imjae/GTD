using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Map : MonoBehaviour
{
    public GameObject slime;
    public Transform respawnPoint;

    public GameObject parent;

    // ��������Ʈ �������� �޾ƿ�
    public GameObject SpawnEffect;

    [SerializeField] 
    private SlimeMonsterFactory slimeFactory = null;
    [SerializeField]
    private SkeletonMonsterFactory skeletonFactory = null;
    [SerializeField]
    private OrcMonsterFactory orcFactory = null;
    [SerializeField]
    private GolemMonsterFactory golemFactory = null;
    [SerializeField]
    private DragonMonsterFactory dragonFactory = null;

    public Vector3[] wayPoint = new Vector3[]{
        new Vector3(45f, -0.5f, -26.89f),
        new Vector3(45f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, -56.89f),
        new Vector3(-75f, -0.5f, 3.1f),
        new Vector3(45f, -0.5f, -26.89f)
    };


    void Start()
    {
        InvokeRepeating("CreateMonster", 1f, GameManager.Instance.monsterRespawnTime);
    }

    void Update()
    {
        
    }

    private void CreateMonster()
    {
        // �������� ��ü ���ͼ� ����

        if (GameManager.Instance.playTime <= 10f)
        {
            this.slimeFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        } 
        else if (GameManager.Instance.playTime <= 20f)
        {
            CameraManager.Instance.BossCameraOn();
            // ���� ���� ���
            GameManager.Instance.EmergenceBoss();
            // Exploer �ִϸ��̼� �ߵ��� ���� ��ũ��Ʈ �̾��� (SpawnExploer)
            SpawnEffect.GetComponent<Animator>().SetTrigger("ExploerTrigger");




            this.skeletonFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
        else if (GameManager.Instance.playTime <= 30f)
        {
            this.orcFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
        else if (GameManager.Instance.playTime <= 40f)
        {
            this.golemFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
        // �巡�� ������ ���� �ִϸ��̼����� ������ ����
        else if(GameManager.Instance.playTime >40f && GameManager.Instance.currentMonsterCount == 0)
        {
            // ���� ���� ���
            GameManager.Instance.EmergenceBoss();


            this.dragonFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
    }

}
