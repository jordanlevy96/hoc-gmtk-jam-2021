using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CardGenerator : MonoBehaviour
{
    public List<Tile> Tiles;
    public Tilemap Grid;
    private System.Random Rand = new System.Random();

    private static Vector3 CARD_SCALE = new Vector3(1.3f, 1.3f, 1);
    private static Vector3 CARD_OFFSET = new Vector3(8, 0, -1);

    public GameObject DrawCard()
    {
        Debug.Log("Drawing Card...");
        int randi = Rand.Next(Tiles.Count);
        Tile tile = Tiles[randi];

        GameObject card = new GameObject();
        card.transform.SetParent(Grid.transform);
        card.transform.localScale = CARD_SCALE;
        card.transform.Translate(CARD_OFFSET);
        SpriteRenderer sr = card.AddComponent<SpriteRenderer>();
        sr.sprite = tile.sprite;
        card.AddComponent<BoxCollider2D>();
        card.AddComponent<Card>();

        return card;
    }
}
