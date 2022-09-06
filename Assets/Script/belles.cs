using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class belles : MonoBehaviour
{
    public GameObject puz_manager;
    public GameObject[] bell;
    int[] bellcount_answer = { 3, 3, 3, 3, 0, 0 };
    int count = 0;
    public float waittime;

    public void light_ON(int a)
    {
        //버튼의 불을 킴
        StartCoroutine(light_OFF(a));

        //버튼을 누르는 순서가 잘못됬을 경우 초기화
        if (bellcount_answer[count] != a)
        {
            count = 0;
        }
        else
        {
            count++;
            if (count == bellcount_answer.Length)
            {
                Debug.Log("clear");
                puz_manager.GetComponent<puzzle_manager_Chapter_2>().open_lab();
            }
        }
    }

    IEnumerator light_OFF(int a)
    {
        bell[a].GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(waittime);
        bell[a].GetComponent<Image>().color = Color.white;
    }
}
