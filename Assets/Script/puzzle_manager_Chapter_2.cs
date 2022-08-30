using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle_manager_Chapter_2 : MonoBehaviour
{
    //public GameObject Gamemanager;

    public GameObject lab_Scrollview, lab_open_door;
    public GameObject bottle;

    public GameObject locker;
    public GameObject storage;

    public GameObject letter;
    public GameObject key;
    public bool has_key = false;
    bool letter_pos = false;

    public GameObject office;
    public GameObject passageway;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void open_lab()
    {
        lab_Scrollview.GetComponent<ScrollRect>().horizontal = true;
        lab_open_door.SetActive(true);
        //lab_open_door.GetComponent<RectTransform>().position = new Vector2(0,0);
    }

    public void open_locker()
    {
        locker.SetActive(false);
        storage.SetActive(true);
    }

    public void letter_show()
    {
        if (!letter_pos)
        {
            letter.GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            letter_pos = true;
        }
        else
        {
            letter.GetComponent<Transform>().localPosition = new Vector3(0, -100, 0);
            letter_pos = false;
        }
    }

    public void get_key()
    {
        has_key = true;
        Debug.Log(has_key);
        key.SetActive(false);
    }

    public void Open_Office()
    {
        if (has_key)
        {
            office.SetActive(true);
            passageway.SetActive(false);
        }
        else
        {
            Debug.Log("고명철 교수 출입금지 (문이 잠겨있다.)");
            //Gamemanager.GetComponent<GameManager>().MessageBox("고명철 교수", "출입금지\n(문이 잠겨있다.)");
        }
    }

}
