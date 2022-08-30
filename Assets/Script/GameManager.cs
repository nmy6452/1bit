using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject camera;
    GameObject message;
    GameObject passageway;
    public GameObject MsgBoxPrefab;
    public bool hasdata = false;
    public bool clear_c1, clear_c2, clear_c3 = false;
    public float WaitForMessage;
    public bool Messageing;

    public Button[] But_mainmenu;


    void Start()
    {
        camera = GameObject.Find("Main Camera");
        message = GameObject.Find("message");
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(camera);
        DontDestroyOnLoad(message);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }


    public void MessageBox(string Title, string Text)
    {
        //메시지 박스 프리팹 가져와서 텍스트를 넣음
        Messageing = true;
        Debug.Log(MsgBoxPrefab);
        GameObject MsgBox = Instantiate(MsgBoxPrefab, new Vector3(0,0,0), Quaternion.identity, GameObject.Find("message").transform);
        Debug.Log(MsgBox);
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
        if (hasdata)
        {
            if (clear_c3)
                MessageBox("알림", "이미 게임을 완료했습니다.");
            else if (clear_c2)
                MessageBox("알림", "아직개발중입니다.");
            else if (clear_c1)
                MessageBox("알림", "아직개발중입니다.");
            else
                SceneManager.LoadScene("Chapter_1_A");
        }
        else
            MessageBox("알림", "게임을 새로 시작하세요");
    }

    public void Select_Neumann()
    {
        SceneManager.LoadScene("Chapter_P_story_A");
        hasdata = true;
    }

    public void Select_Turing()
    {
        SceneManager.LoadScene("Chapter_P_story_A");
        hasdata = true;
    }

    public void Chapter_P_A()
    {
        SceneManager.LoadScene("Chapter_P_A");
    }

    public void PA_C1A()
    {
        SceneManager.LoadScene("Chapter_1_A");
    }

    public void C1A_clear()
    {
        if (clear_c1)
        {
            SceneManager.LoadScene("Chapter_1_story_A");
        }
    }

    public void C1A_C2A()
    {
        SceneManager.LoadScene("Chapter_2_A");
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Main");
    }

    void ClearGameData()
    {
        clear_c1 = false;
        clear_c2 = false;
        clear_c3 = false;
        hasdata = false;
    }

}