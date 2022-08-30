using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Compass : MonoBehaviour
{
    GameObject puzzle_manager;
    public GameObject needle;
    int rotate = 0;
    public int Key;


    private void Start()
    {
        puzzle_manager = GameObject.Find("PuzzleManager");
    }
    void OnEnable()
    {
        needle.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void needle_Rotate()
    {
        if (rotate >= 7){
            rotate = 0;}
        else{
            rotate++;}

        needle.transform.eulerAngles = new Vector3(0, 0, rotate*-45);
    }

    public void Open()
    {
        if (Key == rotate)
        {
            puzzle_manager.GetComponent<puzzle_manager_Chapter_2>().open_locker();
            Debug.Log("Open");
        }
        else
        {
            Debug.Log("Lock");
        }
    }
}
