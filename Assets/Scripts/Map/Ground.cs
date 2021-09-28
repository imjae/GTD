using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject towerSpawnEffect;
    private ParticleSystem effectlight;
    private ParticleSystem effectlight2;
    private ParticleSystem effectmagicCircle;
    private ParticleSystem effectflash;
    private ParticleSystem effectflash2;

    private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        effectlight = towerSpawnEffect.transform.Find("Light").gameObject.GetComponent<ParticleSystem>();
        effectlight2 = towerSpawnEffect.transform.Find("Light2").gameObject.GetComponent<ParticleSystem>();
        effectmagicCircle = towerSpawnEffect.transform.Find("magicCircle").gameObject.GetComponent<ParticleSystem>();
        effectflash = towerSpawnEffect.transform.Find("flash").gameObject.GetComponent<ParticleSystem>();
        effectflash2 = towerSpawnEffect.transform.Find("flash2").gameObject.GetComponent<ParticleSystem>();

        effectlight.Stop();
        effectlight2.Stop();
        effectmagicCircle.Stop();
        effectflash.Stop();
        effectflash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(isFirst)
           

        isFirst = false;

    }

    private void OnMouseDown()
    {
        GameObject a = Instantiate(towerSpawnEffect, transform);
        effectlight.Stop();
        effectlight2.Stop();
        effectmagicCircle.Stop();
        effectflash.Stop();
        effectflash.Stop();
        effectmagicCircle.Play();
    }

}
