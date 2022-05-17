using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject camera;
    public GameObject MsgBoxPrefab;
    public bool clear_c1, clear_c2, clear_c3 = false;
    public float WaitForMessage;
    public bool Messageing;


    void Start()
    {
        camera = GameObject.Find("Main Camera");
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(camera);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("Chapter_1_A_passageway");
    }

    public void Select_Neumann()
    {
        SceneManager.LoadScene("Chapter_P_story_A");
    }

    public void PA_C1A()
    {
        SceneManager.LoadScene("Chapter_1_A_passageway");
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

}