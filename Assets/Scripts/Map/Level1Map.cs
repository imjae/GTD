using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Map : MonoBehaviour
{
    public Transform respawnPoint;

    public GameObject parent;

    // 스폰이펙트 폭발위해 받아옴
    public GameObject SpawnEffect;

    [SerializeField] 
    private SlimeMonsterFactory slimeFactory = null;
    //[SerializeField]
    //private SkeletonMonsterFactory skeletonFactory = null;
    //[SerializeField]
    //private OrcMonsterFactory orcFactory = null;
    //[SerializeField]
    //private GolemMonsterFactory golemFactory = null;
    //[SerializeField]
    //private DragonMonsterFactory dragonFactory = null;

    public GameObject[] wayPoint;

    void Start()
    {
        InvokeRepeating("CreateMonster", 1f, GameManager.Instance.monsterRespawnTime);
    }

    void Update()
    {

    }

    private void CreateMonster()
    {
        // 리스폰된 전체 몬스터수 증가

        if (GameManager.Instance.playTime <= 10f)
        {
            this.slimeFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        } 
        else if (GameManager.Instance.playTime <= 20f)
        {
            EmergenceBoss();



            //this.skeletonFactory.Spawn(parent.transform, respawnPoint.localPosition);
            //GameManager.Instance.currentMonsterCount++;
        }
        /*else if (GameManager.Instance.playTime <= 30f)
        {
            this.orcFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
        else if (GameManager.Instance.playTime <= 40f)
        {
            this.golemFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }
        // 드래곤 보스몹 출현 애니메이션으로 변경할 예정
        else if(GameManager.Instance.playTime >40f && GameManager.Instance.currentMonsterCount == 0)
        {
            // 보스 출현 경고
            GameManager.Instance.EmergenceBoss();


            this.dragonFactory.Spawn(parent.transform, respawnPoint.localPosition);
            GameManager.Instance.currentMonsterCount++;
        }*/
    }

    void EmergenceBoss()
    {
        CancelInvoke();
        // 보스 카메라 변경
        CameraManager.Instance.BossCameraOn();
        // 보스 출현 경고
        GameManager.Instance.WarningEmergenceBoss();
        // Exploer 애니메이션 발동후 폭발 스크립트 이어짐 (SpawnExploer)
        SpawnEffect.GetComponent<Animator>().SetTrigger("ExploerTrigger");

    }
}
