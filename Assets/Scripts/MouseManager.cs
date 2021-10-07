using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject TowerSpwanEffect;

    private ParticleSystem spawnPaticle;

    private GameObject select;
    GameObject target;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 1.5f, 0);
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
                target = hit.transform.gameObject;
                if (GameManager.Instance.isDestroy)
                {
                    if(target.tag == "Tower")
                    {
                        Destroy(target.gameObject);
                    }
                }
                else if(target.tag == "TowerGround")
                {
                    Transform targetTransform = target.transform;
                    select.transform.position = select.transform.position + offset;
                }
            }
        }
    }
}
