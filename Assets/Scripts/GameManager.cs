using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static List<GameObject> Hand;
    private static GameObject DatingCourt;

    public int SameMatchScore;
    public int CloseMatchScore;
    public int WinThreshold;
    public TextMeshProUGUI Score;
    public static int CurrentScore;

    // Start is called before the first frame update
    void Start()
    {
        if (!gm)
        {
            gm = this;
            Hand = new List<GameObject>(); 
            DatingCourt = GameObject.Find("DatingCourt");
            CurrentScore = 0;
        }
    }

    void Update()
    {
        
    }

    public static void ToggleDating()
    {
        bool status = DatingCourt.activeSelf;
        DatingCourt.SetActive(!status);
    }
}
