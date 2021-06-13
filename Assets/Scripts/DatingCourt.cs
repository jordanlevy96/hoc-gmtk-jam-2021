using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingCourt : MonoBehaviour
{
    public static Card[,] Court;

    static int Height = 4;
    static int Width = 4;

    // Start is called before the first frame update
    void Start()
    {
        Court = new Card[Width, Height];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static int CheckNeighbors(int x, int y)
    {
        // TODO: display something?
        // FIXME: not accounting for neighbors that have already been counted!!!

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

    public static void Evaluate()
    {
        int score = 0;

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                score += CheckNeighbors(x, y);
            }
        }

        GameManager.CurrentScore = score;
    }
}
