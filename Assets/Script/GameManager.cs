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
        if(Input.GetButtonDown("Horizontal"))
        {
            if (camera.transform.position.x <= 0 && Input.GetAxisRaw("Horizontal") == -1)
                camera.transform.position = new Vector3(75, 0, -10); 
            else if (camera.transform.position.x >= 75 && Input.GetAxisRaw("Horizontal") == 1)
                camera.transform.position = new Vector3(0, 0, -10);
            else
                camera.transform.position += new Vector3(25, 0, 0) * Input.GetAxisRaw("Horizontal");
        }
        
    }

    public void but_newGame()
    {
        SceneManager.LoadScene("Character_selection", LoadSceneMode.Additive);
    }

    public void Character_select()
    {
        SceneManager.LoadScene("prologue");
    }

    public void new_gamestart()
    {
        SceneManager.LoadScene("A stage1_5f");
    }

}