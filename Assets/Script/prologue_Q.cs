using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class prologue_Q : MonoBehaviour
{

    public InputField InputField_password_1;
    public InputField InputField_password_2;
    public InputField InputField_password_3;
    public InputField InputField_password_4;

    public Button Button_Submit;

    private string password_1 = "3";
    private string password_2 = "4";
    private string password_3 = "6";
    private string password_4 = "8";

    public void password_Submit()
    {
        if (InputField_password_1.text == password_1 && InputField_password_2.text == password_2 && InputField_password_3.text == password_3 && InputField_password_4.text == password_4)
            SceneManager.LoadScene("Chapter_1_A_passageway");
        else
            Debug.Log("비밀번호가 틀렸습니다.");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
