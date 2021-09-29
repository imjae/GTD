using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� ���� ����
    public bool isPause = true;
    // ���� ��� �ð�
    public float playTime;

    // ���� ���̵�
    public int currentDifficuty = 1;
    // ���� ���� ���
    public int currentGold = 0;
    // ���� ������ ���� ��
    public int currentMonsterCount = 0;
    // ���ӿ��� ���� ���ͼ�
    public int monsterGameoverCount = 100;
    // ���� ���� ���� �ð�
    public float generatedMonsterTime = 0.0f;


    // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static GameManager _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
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

    // ���� ���� �Լ�
    public void GeneratedMonster()
    {

    }

    // ���ӿ��� �Ǵ� �Լ�
    public bool JudgmentGameover()
    {
        // ���� ���� ���� ���� ���� ���� ũ�ų� �����̸� True(���ӿ���) ��ȯ
        if (this.currentMonsterCount >= monsterGameoverCount)
            return true;
        else
            return false;
    }

    // ���̵� ����
    public void SettingDifficuty(int difficury)
    {
        switch (difficury)
        {
            case 1:
                    // ���̵� 1�϶� ����
                    break;
            case 2:
                    // ���̵� 2�϶� ����
                    break;
            case 3:
                    // ���̵� 3�϶� ����
                    break;
            default:
                Debug.Log($"���̵��� ������ �ּ���");
                break;
        }
    }
}
