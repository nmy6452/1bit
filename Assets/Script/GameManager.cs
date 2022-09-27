using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject Gamemanager;
    GameObject message;
    GameObject camera;
    GameObject Main_menu;
    GameObject passageway;
    public GameObject MsgBoxPrefab;
    public GameObject MainMenuPrefab;
    public float WaitForMessage;
    public bool Messageing;
    public bool ismainmenu = false;

    public Button[] But_mainmenu;


    void Start()
    {
        message = GameObject.Find("message");
        Gamemanager = GameObject.Find("GameManager");
        camera = GameObject.Find("Main Camera");
        DontDestroyOnLoad(message);
        DontDestroyOnLoad(Gamemanager);
        DontDestroyOnLoad(camera);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !ismainmenu)
        {
            ismainmenu = true;
            GameObject MainMenu = Instantiate(MainMenuPrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("message").transform);
            MainMenu.GetComponent<RectTransform>().localPosition = Vector3.zero;
            MainMenu.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Debug.Log("매인 매뉴가 생성되었습니다.");
        }
        
    }


    public void MessageBox(string Title, string Text)
    {
        //메시지 박스 프리팹 가져와서 텍스트를 넣음
        Messageing = true;
        GameObject MsgBox = Instantiate(MsgBoxPrefab, new Vector3(0,0,0), Quaternion.identity, GameObject.Find("message").transform);
        MsgBox.transform.Find("Title").GetComponent<Text>().text = Title;
        MsgBox.transform.Find("Text").GetComponent<Text>().text = Text;
        MsgBox.GetComponent<RectTransform>().localPosition = Vector3.zero;
        MsgBox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        Destroy(MsgBox, WaitForMessage);
    }

    public void Main_Characterselection()
    {
        SceneManager.LoadScene("Character_selection", LoadSceneMode.Additive);

    }

    public void Main_continue()
    {
        if (PlayerPrefs.HasKey("Player"))
        {
            if (PlayerPrefs.GetInt("chapter")  == 2)  
            {
                if (PlayerPrefs.GetInt("Player") == 1)
                {
                    SceneManager.LoadScene("Chapter_2_A");
                }
                else if (PlayerPrefs.GetInt("Player") == 2)
                {
                    SceneManager.LoadScene("Chapter_2_B");
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Player") == 1)
                {
                    SceneManager.LoadScene("Chapter_1_A");
                }
                else if (PlayerPrefs.GetInt("Player") == 2)
                {
                    SceneManager.LoadScene("Chapter_1_B");
                }
            }
        }
        else
            MessageBox("알림", "게임을 새로 시작하세요");
    }

    public void Select_Neumann()
    {
        PlayerPrefs.SetInt("Player", 1);
        SceneManager.LoadScene("Chapter_P_story_A");
    }

    public void Select_Turing()
    {
        PlayerPrefs.SetInt("Player", 2);
        SceneManager.LoadScene("Chapter_P_story_B");
    }

    public void Chapter_P_A()
    {
        SceneManager.LoadScene("Chapter_P_A");
    }

    public void Chapter_P_B()
    {
        SceneManager.LoadScene("Chapter_P_B");
    }

    public void PA_C1A()
    {
        SceneManager.LoadScene("Chapter_1_A");
    }
    public void PA_C1B()
    {
        SceneManager.LoadScene("Chapter_1_B");
    }

    public void C1A_C2A()
    {
        SceneManager.LoadScene("Chapter_2_A");
    }

    public void C1A_C2B()
    {
        SceneManager.LoadScene("Chapter_2_B");
    }

    public void Ending()
    {
        ClearGameData();
        SceneManager.LoadScene("Ending");
    }

    public void Mainmenu()
    {
        ismainmenu = false;
        Destroy(message);
        Destroy(Gamemanager);
        Destroy(camera);
        SceneManager.LoadScene("Main");
    }

    void ClearGameData()
    {
        PlayerPrefs.DeleteAll();
    }


}