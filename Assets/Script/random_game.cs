using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class random_game : MonoBehaviour
{
    public GameObject[] but;
    public GameObject screen;
    public GameObject completion;
    public GameObject But_Panel;
    public GameObject start_but;
    public GameObject PuzzleManager;

    int[] seq = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    bool isStart = false;
    public float waitTime;
    Coroutine coroutine;
    int curr_but_num = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Game_Start(int a)
    {
        Debug.Log(isStart);
        if (!isStart)
        {
            isStart = true;
            start_but.SetActive(false);
            button_shuffle();
            screen.SetActive(true);
            coroutine = StartCoroutine(hint_rev(a));
        }

    }

    public void button_shuffle()
    {
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            int temp = Random.Range(0, 9);
            but[temp].transform.SetParent(screen.transform, false);
            but[temp].transform.SetParent(But_Panel.transform, false);
        }
    }

    IEnumerator hint_rev(int a)
    {
        for (int i = 0; i < seq.Length; i++)
        {
            //현재 이미지기 짝수 또는 홀수 일때 해당 이미지를 바꾸고 해당되지 않을경우는 지운다.
            if ((i + a) % 2 == 0)
            {
                screen.GetComponent<Image>().sprite = but[seq[i]].transform.GetChild(0).GetComponent<Image>().sprite;
                screen.GetComponent<Image>().color = Color.white;
            }
            else
            {
                screen.GetComponent<Image>().color = Color.clear;
            }
            yield return new WaitForSeconds(waitTime);

            //입력받은 버튼이 잘못된 버튼일 경우 게임 종료
            if (curr_but_num != seq[i])
            {
                screen.GetComponent<Image>().color = Color.clear;
                Game_END();
            }
        }
        Game_END();
        success();
    }

    public void but_Input(int a)
    {
        curr_but_num = a;
    }

    void Game_END()
    {
        Debug.Log("종료");
        isStart = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        screen.SetActive(false);
        start_but.SetActive(true);
    }

    void success()
    {
        completion.SetActive(true);
        start_but.GetComponent<Button>().interactable = false;
        Debug.Log("성공");
    }
}
