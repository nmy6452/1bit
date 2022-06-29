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

    /* ---------1번 퍼즐[교실]--------- */
    private int[] puzzle_1_password = { 1, 1, 1, 0, 0, 1, 1, 1, 0 };
    public List<int> puzzle_1_inputPassword;

    /* ---------2번 퍼즐[창고]--------- */
    public InputField[] puzzle_2;
    private int[] puzzle_2_A_password = { 1, 0, 1, 1, 1 };
    public GameObject coffer, wire_box_Panel;


    /* ---------3번 퍼즐[화장실]--------- */
    public GameObject[] mirror_GameObject;
    public Sprite[] mirror;
    public GameObject[] clearmirror_GameObject;
    public float waitForSeconds;
    private bool mirrorActive;
    public InputField puzzle_3;
    private string puzzle_3_A_password = "java";
    public GameObject URL, monitor, monitor_Panel;

    /* ---------4번 퍼즐[엘리베이터]--------- */
    private bool[] puzzle_4_A_password = { false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true};
    public GameObject[] puzzle_4_A_inputPassword;

    public bool Have_fuse = false;


    /* ---------1번 퍼즐--------- */
    public void puzzle_1_input(int a)
    {
        string temp = "";
        puzzle_1_inputPassword.Add(a);

        for (int i = 0; i < puzzle_1_inputPassword.Count; i++)
        {
            temp += puzzle_1_inputPassword[i];
        }
        URL.GetComponent<Text>().text = temp;
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
            URL.GetComponent<Text>().text = "";
            Gamemanager.GetComponent<GameManager>().MessageBox("알림", "오답입니다.");
        }
    }

    public void puzzle_1_clear()
    {
        proviso[0].SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "정답입니다.");
        monitor.GetComponent<Button>().interactable = false;
        monitor_Panel.SetActive(false);
    }


    /* ---------2번 퍼즐--------- */
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
            Gamemanager.GetComponent<GameManager>().MessageBox("알림", "오답입니다.");
        }
    }

    public void puzzle_2_clear()
    {
        coffer.GetComponent<Button>().interactable = false;
        wire_box_Panel.SetActive(false);
        proviso[1].SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "정답입니다.");
    }

    public void getfuse()
    {
        Have_fuse = true;
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "퓨즈를 주웠다.");
    }

    /* ---------3번 퍼즐--------- */


    [SerializeField]
    public void puzzle_3_mirror_clear(int a)
    {
        if(mirrorActive == false)
        { 
            mirror_GameObject[a].GetComponent<Image>().sprite = mirror[0];
            clearmirror_GameObject[a].SetActive(true);
            mirrorActive = true;
            StartCoroutine(puzzle_3_mirror_black(a));
        }
    }

    public IEnumerator puzzle_3_mirror_black(int a)
    {
        yield return new WaitForSeconds(waitForSeconds);
        mirror_GameObject[a].GetComponent<Image>().sprite = mirror[1];
        clearmirror_GameObject[a].SetActive(false);
        mirrorActive = false;
    }

    public void puzzle_3_password_Submit()
    {
        if (puzzle_3_A_password == puzzle_3.text)
        {
            puzzle_3_clear();
        }
        else
            Gamemanager.GetComponent<GameManager>().MessageBox("알림", "오답입니다.");
    }

    public void puzzle_3_clear()
    {
        proviso[2].SetActive(true);
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "정답입니다.");
    }

    /* ---------4번 퍼즐--------- */

    public void puzzle_4_Open() 
    {
        if (Have_fuse)
        {
            elevator_panel.SetActive(true);
        }
        else
            Gamemanager.GetComponent<GameManager>().MessageBox("알림", "엘리베이터의 퓨즈가 빠져있다.");
    }

    public void puzzle_4_password_Submit()
    {
        for (int i = 0; i < puzzle_4_A_inputPassword.Length; i++)
        {
            if (puzzle_4_A_inputPassword[i].GetComponent<Toggle>().isOn != puzzle_4_A_password[i])
            {
                Gamemanager.GetComponent<GameManager>().MessageBox("알림", "오답입니다.");
                return;
            }
        }
        puzzle_4_clear();
    }

    private void puzzle_4_clear()
    {
        Gamemanager.GetComponent<GameManager>().MessageBox("알림", "정답입니다");
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
            Gamemanager.GetComponent<GameManager>().MessageBox("알림", "엘리베이터가 활성화되지 않았습니다.");
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