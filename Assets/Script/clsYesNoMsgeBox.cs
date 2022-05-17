using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clsYesNoMsgeBox : MonoBehaviour
{

    public string Title, Text;

    // Use this for initialization
    void Start()
    {
        this.transform.Find("Title").GetComponent<Text>().text = Title;
        this.transform.Find("Text").GetComponent<Text>().text = Text;
    }
}