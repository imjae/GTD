using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;
    // 보스 출연 연출 끝남을 알리는 플래그
    public bool isFInishBossMovie = false;

    //보스가 처음 출현해서 하는 행동을 정의하기 위한 플래그
    private bool isFirst = true;
    // 보스가 처음 생성된 위치
    private Vector3 startPosition;
    // 보스가 처음 생성된 위치에서 이동할 위치
    private Vector3 startMovePosition = new Vector3(-0.32f, -7.65f, -0.69f);
    


    private float bossSurviveTime = 0.0f;
    void Start()
    {
        fireBreath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.localPosition = Vector3.MoveTowards(startPosition, startMovePosition, 0.1f);
        isFirst = false;
        
    }

    private void FixedUpdate()
    {
        bossSurviveTime += Time.deltaTime;

        if(bossSurviveTime <= 1.6f)
        {
            transform.Translate(Vector3.forward * 0.15f);
        }

        if(isFInishBossMovie)
        {

        }
    }

    void ActiveBreath()
    {
        fireBreath.SetActive(true);
    }

    void UnActiveBreath()
    {
        fireBreath.SetActive(false);
    }
}
