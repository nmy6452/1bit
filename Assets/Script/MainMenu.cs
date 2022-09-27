using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject Gamemanager;

    private void Awake()
    {
        Gamemanager = GameObject.Find("GameManager");
    }

    public void quit()
    {
        Destroy(gameObject);
        Gamemanager.GetComponent<GameManager>().ismainmenu = false;
    }

    public void main_menu()
    {
        Gamemanager.GetComponent<GameManager>().Mainmenu();
        Destroy(gameObject);
        SceneManager.LoadScene("Main");
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
