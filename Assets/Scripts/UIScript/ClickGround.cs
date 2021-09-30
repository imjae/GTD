using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popup;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Å¬¸¯");
        GameObject temp = Instantiate(popup, transform.position, transform.rotation);
        temp.GetComponent<BuildClickManager>().groundTransform = transform;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
