using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class puzzle_manager_Chapter_1 : MonoBehaviour
{
    [SerializeField]
    private RectTransform leverpositon;
    private RectTransform rectTransform;

    public GameObject lever;

    public Button Button_0;
    public Button Button_1;

    public int[] puzzle_1_password = { 1, 1, 1, 0, 0, 1, 1, 1, 0 };
    public List<int> puzzle_1_inputPassword;

    public void puzzle_1_input(int a)
    {
        Debug.Log(a);
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
            Debug.Log("정답입니다.");
        else
            puzzle_1_inputPassword = new List<int>();
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