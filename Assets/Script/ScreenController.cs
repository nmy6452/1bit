using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{

    public GameObject passway;
    public GameObject contant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (passway.activeSelf == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (contant.GetComponent<RectTransform>().position.x >= -960)
                {
                    contant.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                }
                else if (contant.GetComponent<RectTransform>().position.x >= -2880)
                {
                    contant.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1920, 0, 0);
                }
                else if (contant.GetComponent<RectTransform>().position.x >= -4800)
                {
                    contant.GetComponent<RectTransform>().anchoredPosition = new Vector3(-3840, 0, 0);
                }
                else
                {
                    contant.GetComponent<RectTransform>().anchoredPosition = new Vector3(-5760, 0, 0);
                }
            }
        }
    }
}
