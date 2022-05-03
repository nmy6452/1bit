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

    public void but_Chapter1_Classroom()
    {
        SceneManager.LoadScene("Chapter_1_A_Classroom", LoadSceneMode.Additive);
    }

    public void but_Chapter1_Classroom_quit()
    {
        SceneManager.UnloadSceneAsync("Chapter_1_A_Classroom");
    }

}