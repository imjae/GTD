using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 카메라 흔들기
    public float shakeAmount;
    float shakeTime;

    Vector3 initialPosition;

    public void VibrateForTime(float time)
    {
        shakeTime = time;
    }
    // Start is called before the first frame update
    void Start()
    {
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
