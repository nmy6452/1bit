using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puzzle_manager_Chapter_1 : MonoBehaviour
{
    public GameObject Gamemanager;
    public GameObject[] proviso;
    public GameObject elevator_panel;

    private int[] puzzle_1_password = { 1, 1, 1, 0, 0, 1, 1, 1, 0 };
    public List<int> puzzle_1_inputPassword;

    public InputField[] puzzle_2;
    private int[] puzzle_2_A_password = { 1, 0, 1, 1, 1 };

    public GameObject[] mirror;
    public GameObject[] clearmirror;
    public float waitForSeconds;
    private bool mirrorActive;
    public InputField puzzle_3;
    private string puzzle_3_A_password = "java";

    private bool[] puzzle_4_A_password = { false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true};
    public GameObject[] puzzle_4_A_inputPassword;

    public bool Have_fuse = false;


    /* ---------1�� ����--------- */
    public void puzzle_1_input(int a)
    {
        string temp = "";
        puzzle_1_inputPassword.Add(a);

        for (int i = 0; i < puzzle_1_inputPassword.Count; i++)
        {
            temp += puzzle_1_inputPassword[i];
        }
        Gamemanager.GetComponent<GameManager>().MessageBox("�Է�", temp);
    }
    public bool puzzle_1_Check()
    {
        int[] temp = puzzle_1_inputPassword.ToArray();
        bool Check = false;

        if (puzzle_1_password.SequenceEqual(temp))
        {
            Check = true;
        }
        return Check;
    }

    public void puzzle_1_Submit()
    {
        if (puzzle_1_Check())
        {
            puzzle_1_clear();
        }
        else
        {
            puzzle_1_inputPassword = new List<int>();
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
        }
    }

    public void puzzle_1_clear()
    {
            proviso[0].SetActive(true);
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
    }


    /* ---------2�� ����--------- */
    public bool puzzle_2_Check()
    {
        for (int i = 0; i < puzzle_2.Length; i++)
        {
            if (puzzle_2[i].text == "")
            {
                return false;
            }
            else
            {
                if (int.Parse(puzzle_2[i].text) != puzzle_2_A_password[i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void puzzle_2_Submit()
    {
        if (puzzle_2_Check())
        {
            puzzle_2_clear();
        }
        else
        {
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
        }
    }

    public void puzzle_2_clear()
    {
        GameObject.Find("Chapter_1_puzzle_2_A").SetActive(false);
        proviso[1].SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
    }

    public void getfuse()
    {
        Have_fuse = true;
        Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "ǻ� �ֿ���.");
    }

    /* ---------3�� ����--------- */


    [SerializeField]
    public void puzzle_3_mirror_clear(int a)
    {
        if(mirrorActive == false)
        { 
            mirror[a].SetActive(false);
            clearmirror[a].SetActive(true);
            mirrorActive = true;
            StartCoroutine(puzzle_3_mirror_black(a));
        }
    }

    public IEnumerator puzzle_3_mirror_black(int a)
    {
        yield return new WaitForSeconds(waitForSeconds);
        mirror[a].SetActive(true);
        clearmirror[a].SetActive(false);
        mirrorActive = false;
    }

    public void puzzle_3_password_Submit()
    {
        if (puzzle_3_A_password == puzzle_3.text)
        {
            puzzle_3_clear();
        }
        else
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
    }

    public void puzzle_3_clear()
    {
        proviso[2].SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
    }

    /* ---------4�� ����--------- */

    public void puzzle_4_Open() 
    {
        if (Have_fuse)
        {
            elevator_panel.SetActive(true);
        }
        else
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "������������ ǻ� �����ִ�.");
    }

    public void puzzle_4_password_Submit()
    {
        for (int i = 0; i < puzzle_4_A_inputPassword.Length; i++)
        {
            if (puzzle_4_A_inputPassword[i].GetComponent<Toggle>().isOn != puzzle_4_A_password[i])
            {
                Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�.");
                return;
            }
        }
        puzzle_4_clear();
    }

    private void puzzle_4_clear()
    {
        Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "�����Դϴ�");
        Gamemanager.GetComponent<GameManager>().clear_c1 = true;
        for (int i = 0; i < puzzle_4_A_inputPassword.Length; i++)
        {
            puzzle_4_A_inputPassword[i].GetComponent<Toggle>().interactable = false;
        }
    }

    public void C1A_clear()
    {
        if (Gamemanager.GetComponent<GameManager>().clear_c1)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            Gamemanager.GetComponent<GameManager>().MessageBox("�˸�", "���������Ͱ� Ȱ��ȭ���� �ʾҽ��ϴ�.");
        }
    }

    // Start is called before the first frame updat
    private void Awake()
    {
        puzzle_1_inputPassword = new List<int>();
        Gamemanager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {

    }
}