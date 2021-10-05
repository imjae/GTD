using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("VictoryTrigget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
