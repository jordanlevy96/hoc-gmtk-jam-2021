using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static List<GameObject> Hand;
    private static GameObject DatingCourtGO;
    private static CardGenerator Generator;

    public int SameMatchScore;
    public int CloseMatchScore;
    public int WinThreshold;
    public TextMeshProUGUI Score;
    public static int CurrentScore;
    public static bool AITurnActive;
    public static int TurnsTaken;

    void Awake()
    {
        if (!gm)
        {
            gm = this;
            Hand = new List<GameObject>(); 
            DatingCourtGO = GameObject.Find("DatingCourt");
            Generator = GameObject.Find("CardGenerator").GetComponent<CardGenerator>();
            CurrentScore = 0;
            AITurnActive = false;
            TurnsTaken = 0;
        }
    }

    public static void AITurn()
    {
        AITurnActive = true;

        GameObject cardGO = Generator.DrawCard();
        Card card = cardGO.GetComponent<Card>();
        Vector3Int pos = DatingCourt.FindRandomSpace();
        TileManager.tm.PlaceCard(card, pos);

        AITurnActive = false;
    }

    public static void ToggleDating()
    {
        bool status = DatingCourtGO.activeSelf;
        DatingCourtGO.SetActive(!status);
    }
}
