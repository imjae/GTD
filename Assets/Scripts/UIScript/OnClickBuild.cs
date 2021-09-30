using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBuild : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buildButton;
    void Start()
    {
        
    }
    public void MakeBuildButton()
    {
        Instantiate(buildButton, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
