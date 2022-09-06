using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class navigation_puzzle : MonoBehaviour
{
    public RectTransform Startpoint,Endpoint;
    public GameObject PuzzleManager;
    public GameObject cross;
    string[] password = {"up", "right", "right", "down", "right", "right", "up", "up", "up", "right", "right",  "down", "right", "right", "up", "right" };
    public List<string> password_input;
    // Start is called before the first frame "up"date
    void Start()
    {
        PuzzleManager = GameObject.Find("PuzzleManager");
        Startpoint = GameObject.Find("StartPoint").GetComponent<RectTransform>();
        Endpoint = GameObject.Find("EndPoint").GetComponent<RectTransform>();
        cross = GameObject.Find("Cross");
        cross.transform.SetParent(Startpoint, false);
        cross.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void Cross_init()
    {
        cross.transform.SetParent(Startpoint, false);
        password_input.Clear();

        for (int i = 0; i < 40; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 225, 225);
            transform.GetChild(i).gameObject.tag = "road";
        }
    }

    public void Croos_tile(int a)
    {
        //레이케스트 초기화
        float MaxDistance = 50f;
        Vector3 cross_pos = cross.transform.parent.transform.position;
        RaycastHit2D hit;


        //레이케스트 발사
        if (a == 1)
        {
            Debug.DrawRay(cross_pos += new Vector3(-50, 0, 0), Vector3.left * MaxDistance, Color.blue, 1f);
            hit = Physics2D.Raycast(cross_pos += new Vector3(-50, 0, 0), Vector3.left, MaxDistance);
            password_input.Add("left");
        }
        else if (a == 2)
        {
            Debug.DrawRay(cross_pos += new Vector3(50, 0, 0), Vector3.right * MaxDistance, Color.blue, 1f);
            hit = Physics2D.Raycast(cross_pos += new Vector3(50, 0, 0), Vector3.right, MaxDistance);
            password_input.Add("right");
        }
        else if (a == 3)
        {
            Debug.DrawRay(cross_pos += new Vector3(0, 50, 0), Vector3.up * MaxDistance, Color.blue, 1f);
            hit = Physics2D.Raycast(cross_pos += new Vector3(0, 50, 0), Vector3.up, MaxDistance);
            password_input.Add("up");
        }
        else
        {
            Debug.DrawRay(cross_pos += new Vector3(0, -50, 0), Vector3.down * MaxDistance, Color.blue, 1f);
            hit = Physics2D.Raycast(cross_pos += new Vector3(0, -50, 0), Vector3.down, MaxDistance);
            password_input.Add("down");
        }

        //레이케스트가 맞을 경우
        if (hit.collider != null)
        {
            if (hit.collider.tag == "road")
            {
                cross.transform.parent.tag = "stop";
                cross.transform.parent.GetComponent<Image>().color = Color.gray;
                cross.transform.SetParent(hit.transform, false);
            }
            if (hit.collider.name == "EndPoint" && Croos_tile())
            {
                Debug.Log("정답입니다.");
                SceneManager.LoadScene("Ending");
            }
        }
    }

    bool Croos_tile()
    {
        for (int i = 0; i < password_input.Count; i++)
        {
            if (password_input[i] != password[i])
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Croos_tile(1);
        }
    }
}
