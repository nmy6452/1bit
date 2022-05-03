using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class puzzle_manager_Chapter_1 : MonoBehaviour
{
    public GameObject proviso;

    public InputField[] puzzle_2;
    private int[] puzzle_2_A_password = { 1, 0, 1, 1, 1 };

    private int[] puzzle_1_password = { 1, 1, 1, 0, 0, 1, 1, 1, 0 };
    public List<int> puzzle_1_inputPassword;


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
        int[] Check = new int[5];
        for (int i = 0; i < puzzle_2.Length; i++)
        {
            Check[i] = int.Parse(puzzle_2[i].text);
        }
        return Check.SequenceEqual(puzzle_2_A_password);
    }

    public void puzzle_2_Submit()
    {
        if(puzzle_2_solve())
        {
            Debug.Log("정답입니다.");
        }
        else
        {
            Debug.Log("오답입니다.");
        }
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