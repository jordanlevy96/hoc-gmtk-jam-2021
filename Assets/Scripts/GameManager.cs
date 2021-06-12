using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> Hand;
    private static GameObject DatingCourt;

    // Start is called before the first frame update
    void Start()
    {
        Hand = new List<GameObject>(); 
        DatingCourt = GameObject.Find("DatingCourt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HideDating()
    {
        DatingCourt.SetActive(false);
    }
}
