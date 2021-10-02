using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SpawnExploerEffect;

    // 폭발 불
    public GameObject fireBirPurple;
    // 폭발 불 가루
    public GameObject fireFliesPurple;

    private ParticleSystem system;

    // 보스 소환 마법진
    public GameObject bossPortal;
    public GameObject boss;

    private void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    void SpawnExploer()
    {
        Instantiate(SpawnExploerEffect, transform.position, Quaternion.identity);
        // 불 가루 효과
        Instantiate(fireFliesPurple);

        GameObject fire1 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);
        GameObject fire2 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);
        GameObject fire3 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);
        GameObject fire4 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);
        GameObject fire5 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);
        GameObject fire6 = Instantiate(fireBirPurple, transform.position, Quaternion.identity);

        Vector3 fire1VectorNormal = new Vector3(-1f, 0.4f, 0f).normalized;
        fire1.GetComponent<Rigidbody>().AddForce(fire1VectorNormal * 400f);
        Vector3 fire2VectorNormal = new Vector3(-1f, 0.4f, 0.3f).normalized;
        fire2.GetComponent<Rigidbody>().AddForce(fire2VectorNormal * 1200f);
        Vector3 fire3VectorNormal = new Vector3(-1f, 0.4f, -0.3f).normalized;
        fire3.GetComponent<Rigidbody>().AddForce(fire3VectorNormal * 1200f);
        Vector3 fire4VectorNormal = new Vector3(-1f, 0.5f, 0.2f).normalized;
        fire4.GetComponent<Rigidbody>().AddForce(fire4VectorNormal * 600f);
        Vector3 fire5VectorNormal = new Vector3(-1f, 0.5f, 0.1f).normalized;
        fire5.GetComponent<Rigidbody>().AddForce(fire5VectorNormal * 500f);
        Vector3 fire6VectorNormal = new Vector3(-1f, 0.5f, -0.1f).normalized;
        fire6.GetComponent<Rigidbody>().AddForce(fire6VectorNormal * 200f);

        system.Stop();

        StartCoroutine(BossMovie());
    }

    public IEnumerator BossMovie()
    {
        bool isRoutain = true;
        while (isRoutain)
        {
            // 한번만 반복하도록 변수 설정
            isRoutain = false;

            GameObject clonePortal = Instantiate(bossPortal, transform.position, Quaternion.Euler(-27.088f, 90.7f, -0.013f));
            clonePortal.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(3f);

            GameObject cloneBoss = Instantiate(boss, new Vector3(-0.2f, -5.7f, 6.6f), Quaternion.Euler(27.96f, 181.351f, 1.874f));
            cloneBoss.transform.SetParent(gameObject.transform);
            cloneBoss.transform.localPosition = new Vector3(-0.11f, -3.01f, 8.04f);
            cloneBoss.transform.localRotation = Quaternion.Euler(27.96f, 181.351f, 1.874f);
            yield return new WaitForSeconds(1.6f);

            clonePortal.GetComponent<Animator>().SetTrigger("CloseBossPortal");
            yield return new WaitForSeconds(2f);

            cloneBoss.GetComponent<Animator>().SetTrigger("Attack02Trigger");
            yield return new WaitForSeconds(5f);

            // 불 끄고 나는 모션으로 변경
            cloneBoss.GetComponent<BossBehaviour>().fireBreath.SetActive(false);
            cloneBoss.GetComponent<Animator>().SetTrigger("FlyFWDTrigger");
            yield return new WaitForSeconds(0.3f);

            CameraManager.Instance.MainCameraOn();
        }
    }
}
