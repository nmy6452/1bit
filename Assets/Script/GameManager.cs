using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject camera;

    // Start is called before the first frame update
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

    public void but_newGame()
    {
        SceneManager.LoadScene("Character_selection", LoadSceneMode.Additive);
    }

    public void but_test()
    {
        Debug.Log("¿€µø~!");
    }

    public void Character_select()
    {
        SceneManager.LoadScene("Chapter_P_A");
    }

    public void new_gamestart()
    {
        SceneManager.LoadScene("Chapter_1_A_passageway");
    }

    public void but_C1_passageway_Classroom()
    {
        SceneManager.LoadScene("Chapter_1_A_Classroom", LoadSceneMode.Additive);
    }

    public void but_C1_Classroom_passageway()
    {
        SceneManager.UnloadSceneAsync("Chapter_1_A_Classroom");
    }

    public void but_C1_passageway_RestRoom()
    {
        SceneManager.LoadScene("Chapter_1_A_RestRoom", LoadSceneMode.Additive);
    }

    public void but_C1_RestRoom_passageway()
    {
        SceneManager.UnloadSceneAsync("Chapter_1_A_RestRoom");
    }

    public void but_C1_passageway_Store()
    {
        SceneManager.LoadScene("Chapter_1_A_Store", LoadSceneMode.Additive);
    }

    public void but_C1_Store_passageway()
    {
        SceneManager.UnloadSceneAsync("Chapter_1_A_Store");
    }

}