using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void but_newGame()
    {
        SceneManager.LoadScene("Character_selection", LoadSceneMode.Additive);
    }

    public void Character_select()
    {
        SceneManager.LoadScene("prologue");
    }
}
