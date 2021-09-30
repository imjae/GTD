using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.Translate(Vector3.up * -1f);
    }

    private void OnMouseExit()
    {
        transform.Translate(Vector3.up * 1f);
    }

}
