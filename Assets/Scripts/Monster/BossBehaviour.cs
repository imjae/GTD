using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject fireBreath;

    // Start is called before the first frame update
    void Start()
    {
        fireBreath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
