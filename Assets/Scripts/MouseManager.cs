using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject TowerSpwanEffect;

    private ParticleSystem spawnPaticle;

    private GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        select = Instantiate(TowerSpwanEffect);
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
                Transform targetTransform = target.transform;
                select.transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y + 1.5f, targetTransform.position.z);
            }
        }
    }
}
