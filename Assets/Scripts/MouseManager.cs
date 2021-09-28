using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.transform.gameObject;
                float curX = target.transform.position.x;
                float curY = target.transform.position.y;
                float curZ = target.transform.position.z;

                target.transform.position = new Vector3(curX, curY - 3f, curZ);
            }
        } else if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.transform.gameObject;
                float curX = target.transform.position.x;
                float curY = target.transform.position.y;
                float curZ = target.transform.position.z;

                target.transform.position = new Vector3(curX, curY + 3f, curZ);
            }
        }
    }

    private void OnMouseOver()
    {
        
    }
}
