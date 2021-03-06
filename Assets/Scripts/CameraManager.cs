using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera bossCamera;

    // 카메라 흔들기
    public float shakeAmount;
    float shakeTime;

    Vector3 initialPosition;

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static CameraManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static CameraManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(CameraManager)) as CameraManager;

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


    public void MainCameraOn()
    {
        mainCamera.enabled = true;
        bossCamera.enabled = false;
    }
    public void BossCameraOn()
    {
        mainCamera.enabled = false;
        bossCamera.enabled = true;
    }

    public void VibrateForTime(float time)
    {
        shakeTime = time;
    }
    // Start is called before the first frame update
    void Start()
    {
        MainCameraOn();
        initialPosition = new Vector3(315.4f, 1160f, -995.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
}
