using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;
    // ���� �⿬ ���� ������ �˸��� �÷���
    public bool isFInishBossMovie = false;

    //������ ó�� �����ؼ� �ϴ� �ൿ�� �����ϱ� ���� �÷���
    private bool isFirst = true;
    // ������ ó�� ������ ��ġ
    private Vector3 startPosition;
    // ������ ó�� ������ ��ġ���� �̵��� ��ġ
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
