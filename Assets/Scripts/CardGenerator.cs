using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CardGenerator : MonoBehaviour
{
    public List<Tile> Tiles;
    public Tilemap Grid;
    private System.Random Rand = new System.Random();

    public GameObject DrawCard()
    {
        Debug.Log("Drawing Card...");
        int randi = Rand.Next(Tiles.Count);
        Tile tile = Tiles[randi];

        GameObject card = new GameObject();
        card.transform.SetParent(Grid.transform);
        SpriteRenderer sr = card.AddComponent<SpriteRenderer>();
        sr.sprite = tile.sprite;
        card.AddComponent<BoxCollider2D>();
        card.AddComponent<Card>();

        return card;
    }
}
