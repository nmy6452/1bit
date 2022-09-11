using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle_manager_Chapter_2 : MonoBehaviour
{
    GameObject Gamemanager;
    public PlayableDirector PlayableDirector;
    //public GameObject Gamemanager;
    public GameObject lab_Scrollview, lab_open_door;
    public GameObject bottle;

    public GameObject locker;
    public GameObject storage;

    public GameObject letter;
    public GameObject key;

    public bool has_key = false;
    bool has_envelope = false;

    public GameObject office;
    public GameObject passageway;

    // Start is called before the first frame update
    void Awake()
    {
        Gamemanager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void open_lab()
    {
        lab_Scrollview.GetComponent<ScrollRect>().horizontal = true;
        lab_open_door.SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "연구실 문이 열렸습니다.");
        //lab_open_door.GetComponent<RectTransform>().position = new Vector2(0,0);
    }

    public void open_locker()
    {
        locker.SetActive(false);
        storage.SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "사물홤이 열렸습니다.");
    }

    public void get_key()
    {
        has_key = true;
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "낡은 열쇠를 얻었습니다.");
    }


    public void get_envelope()
    {
        has_envelope = true;
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "낡은 편지를 얻었습니다.");
    }

    public void Submit_envelope()
    {
        if (has_envelope)
        {
            has_envelope = false;
            PlayableDirector.Play();
        }
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
            Gamemanager.GetComponent<GameManager>().MessageBox("고명철 교수", "출입금지\n(문이 잠겨있다.)");
        }
    }

}
