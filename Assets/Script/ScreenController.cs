using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{

    public GameObject passway;
    public GameObject contant;
    public float Movespeed;
    public bool isclick = false;
    const int anchor1 = 0;
    const int anchor2 = -1920;
    const int anchor3 = -3840;
    const int anchor4 = -5760;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

        if (passway.activeSelf == true && !isclick)
        {
            Movecontant();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isclick = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isclick = true;
        }
    }

    void Movecontant()
    {
        if (contant.GetComponent<RectTransform>().position.x >= -960)
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor1, 0, 0), Movespeed);
        }
        else if (contant.GetComponent<RectTransform>().position.x >= -2880)
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor2, 0, 0), Movespeed);
        }
        else if (contant.GetComponent<RectTransform>().position.x >= -4800)
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor3, 0, 0), Movespeed);
        }
        else
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor4, 0, 0), Movespeed);
        }
    }

}
