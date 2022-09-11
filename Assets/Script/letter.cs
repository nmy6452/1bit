using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{
    public GameObject Letter;
    public GameObject Key;
    public GameObject puzzleManager;

    bool letter_pos = false;

    public void get_key()
    {
        Key.SetActive(false);
        puzzleManager.GetComponent<puzzle_manager_Chapter_2>().get_key();
    }

    public void letter_show()
    {
        if (!letter_pos)
        {
            Letter.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
            letter_pos = true;
        }
        else
        {
            Letter.GetComponent<Transform>().localPosition = new Vector3(0, -100, 0);
            letter_pos = false;
        }
    }

}
