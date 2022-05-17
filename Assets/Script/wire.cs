using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    GameObject GameObject;

    public void rotation()
    {
        transform.Rotate(new Vector3(0,0,1), 90f);
    }

    private void Awake()
    {
        GameObject = this.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotation();
        }
    }
}
