using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class puzzle_manager_Chapter_1 : MonoBehaviour
{
    public GameObject proviso;

    private int[] puzzle_1_password = { 1, 1, 1, 0, 0, 1, 1, 1, 0 };
    public List<int> puzzle_1_inputPassword;

    public InputField[] puzzle_2;
    private int[] puzzle_2_A_password = { 1, 0, 1, 1, 1 };

    public GameObject[] mirror;
    public float waitForSeconds;
    private bool mirrorActive;


    /* ---------1번 퍼즐--------- */
    public void puzzle_1_input(int a)
    {
        puzzle_1_inputPassword.Add(a);
    }
    public bool puzzle_1_solve()
    {
        int[] temp = puzzle_1_inputPassword.ToArray();
        bool Check = false;

        if (puzzle_1_password.SequenceEqual(temp))
        {
            Check = true;
        }
        return Check;
    }

    public void puzzle_1_clear()
    {
        if (puzzle_1_solve())
        {
            proviso.SetActive(true);
            Debug.Log("정답입니다.");
        }
        else
            puzzle_1_inputPassword = new List<int>();
    }

    /* ---------2번 퍼즐--------- */
    public bool puzzle_2_solve()
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
        if (puzzle_2_solve())
        {
            Debug.Log("정답입니다.");
        }
        else
        {
            Debug.Log("오답입니다.");
        }
    }

    /* ---------3번 퍼즐--------- */


    [SerializeField]
    public void puzzle_3_mirror_clear(int a)
    {
        if(mirrorActive == false)
        { 
            mirror[a].SetActive(false);
            mirror[a + 1].SetActive(true);
            mirrorActive = true;
            StartCoroutine(puzzle_3_mirror_black(a));
        }

    }

    public IEnumerator puzzle_3_mirror_black(int a)
    {
        yield return new WaitForSeconds(waitForSeconds);
        mirror[a].SetActive(true);
        mirror[a + 1].SetActive(false);
        mirrorActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        puzzle_1_inputPassword = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}