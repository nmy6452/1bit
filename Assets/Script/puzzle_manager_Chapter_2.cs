using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class puzzle_manager_Chapter_2 : MonoBehaviour
{
    public GameObject lab_Scrollview, lab_open_door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open_lab()
    {
        lab_Scrollview.GetComponent<ScrollRect>().horizontal = true;
        lab_open_door.SetActive(true);
        //lab_open_door.GetComponent<RectTransform>().position = new Vector2(0,0);
    }
}
