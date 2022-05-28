using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{

    public GameObject passway;
    public GameObject contant;
    public float Movespeed;
    public bool isMove = false;
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

        if (passway.activeSelf == true && isMove && !isclick)
        {
            Movecontant();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMove = true;
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
            if (contant.GetComponent<RectTransform>().anchoredPosition.x == anchor1)
                isMove = false;
        }
        else if (contant.GetComponent<RectTransform>().position.x >= -2880)
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor2, 0, 0), Movespeed);
            if (contant.GetComponent<RectTransform>().anchoredPosition.x == anchor2)
                isMove = false;
        }
        else if (contant.GetComponent<RectTransform>().position.x >= -4800)
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor3, 0, 0), Movespeed);
            if (contant.GetComponent<RectTransform>().anchoredPosition.x == anchor3)
                isMove = false;
        }
        else
        {
            contant.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(contant.GetComponent<RectTransform>().anchoredPosition, new Vector3(anchor4, 0, 0), Movespeed);
            if (contant.GetComponent<RectTransform>().anchoredPosition.x == anchor4)
                isMove = false;
        }
    }

}
