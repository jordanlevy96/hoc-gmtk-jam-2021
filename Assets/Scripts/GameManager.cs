using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static List<GameObject> Hand;
    private static GameObject DatingCourt;

    public int SameMatchScore;
    public int CloseMatchScore;
    public int WinThreshold;

    // Start is called before the first frame update
    void Start()
    {
        if (!gm)
        {
            gm = this;
            Hand = new List<GameObject>(); 
            DatingCourt = GameObject.Find("DatingCourt");
        }
    }

    public static void ToggleDating()
    {
        bool status = DatingCourt.activeSelf;
        DatingCourt.SetActive(!status);
    }
}
