using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigation_puzzle : MonoBehaviour
{
    public RectTransform Startpoint,Endpoint;
    public GameObject cross;
    // Start is called before the first frame update
    void Start()
    {
        Startpoint = GameObject.Find("StartPoint").GetComponent<RectTransform>();
        Endpoint = GameObject.Find("EndPoint").GetComponent<RectTransform>();
        cross = GameObject.Find("Cross");
        cross.transform.SetParent(Startpoint, false);
        cross.transform.localPosition = new Vector3(50, -50, 0);
    }

    public void Cross_move(int a)
    {
        switch (a)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    bool Croos_tile()
    {
        cross.transform.parent
        return false;
    }

    void Update()
    {
        //if (Input.GetKeyDown("a"))
        //{
        //    gameObject.GetComponent<RectTransform>().position += new Vector3(gameObject.GetComponent<RectTransform>().position.x + 100, 0,0);
        //}
    }
}
