using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 정지 여부
    public bool isPause = true;
    // 게임 경과 시간
    public float playTime;

    // 현재 난이도
    public int currentDifficuty = 1;
    // 현재 보유 골드
    public int currentGold = 0;
    // 현재 생성된 몬스터 수
    public int currentMonsterCount = 0;
    // 게임오버 기준 몬스터수
    public int monsterGameoverCount = 100;
    // 몬스터 생성 간격 시간
    public float monsterRespawnTime = 1.5f;

    CameraManager camera;
    public GameObject dangerText;

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    private void FixedUpdate()
    {
        playTime = Time.time;
    }

    void Update()
    {
        
    }

    // 몬스터 생성 함수
    public void GeneratedMonster()
    {

    }

    // 게임오버 판단 함수
    public bool JudgmentGameover()
    {
        // 현재 몬스터 수가 기준 몬스터 수가 크거나 같앚이면 True(게임오버) 반환
        if (this.currentMonsterCount >= monsterGameoverCount)
            return true;
        else
            return false;
    }

    // 난이도 설정
    public void SettingDifficuty(int difficury)
    {
        switch (difficury)
        {
            case 1:
                    // 난이도 1일때 설정
                    break;
            case 2:
                    // 난이도 2일때 설정
                    break;
            case 3:
                    // 난이도 3일때 설정
                    break;
            default:
                Debug.Log($"난이도를 설정해 주세요");
                break;
        }
    }


   
    public IEnumerator BlinkText()
    {
        int count = 0;
        while(count < 5)
        {
            this.dangerText.SetActive(false);
            yield return new WaitForSeconds(.5f);
            this.dangerText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            count++;
        }
        this.dangerText.SetActive(false);
    }

    public void EmergenceBoss()
    {
        StartCoroutine(BlinkText());
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraManager>();
        camera.VibrateForTime(5f);
    }
}
