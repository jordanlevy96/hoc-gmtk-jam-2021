using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingCourt : MonoBehaviour
{
    public static Card[,] Court;

    static int Height = 4;
    static int Width = 4;
    private static System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        Court = new Card[Width, Height];
        rand = new System.Random();
    }

    public static Vector3Int FindRandomSpace()
    {
        bool taken = true;
        while (taken)
        {
            int x = rand.Next(Width);
            int y = rand.Next(Height);
            if (!Court[x, y])
            {
                return new Vector3Int(x, y, 0);
            }
        }
        
        return Vector3Int.zero;
    }

    private static int CheckNeighbors(int x, int y)
    {
        // TODO: display something?

        Card baseCard = Court[x, y];
        if (!baseCard)
        {
            return 0;
        }

        Card neighbor = null;
        int total = 0;
        int curr = 0;

        if (x > 0)
        {
            neighbor = Court[x-1, y];
            if (neighbor)
            {
                curr = Card.CompareCards(baseCard, neighbor);
                total += curr;
            }
        }

        if (x < Width - 1)
        {
            neighbor = Court[x+1, y];
            if (neighbor)
            {
                curr = Card.CompareCards(baseCard, neighbor);
                total += curr;
            };
        }

        if (y > 0)
        {
            neighbor = Court[x, y-1];
            if (neighbor)
            {
                curr = Card.CompareCards(baseCard, neighbor);
                total += curr;
            }
        }

        if (y < Height - 1)
        {
            neighbor = Court[x, y+1];
            if (neighbor)
            {
                curr = Card.CompareCards(baseCard, neighbor);
                total += curr;
            }
        }

        return total;
    }

    public static void EvaluateScore(int x, int y)
    {
        bool[,] counted = new bool[Width, Height];

        GameManager.CurrentScore += CheckNeighbors(x, y);;
        GameManager.gm.Score.text = "Total Score: " + GameManager.CurrentScore.ToString();
    }
}
