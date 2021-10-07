using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static int count = 0;
    public int current;
    // Start is called before the first frame update
    void Start()
    {
        count++;
        current = count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
