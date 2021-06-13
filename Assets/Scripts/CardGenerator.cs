using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CardGenerator : MonoBehaviour
{
    public Tile Frame;
    public List<Tile> Backgrounds;
    public List<Tile> Characters;
    public Tilemap Grid;
    private System.Random Rand = new System.Random();

    private static Vector3 CARD_SCALE = new Vector3(0.5f, 0.5f, 1);
    private static Vector3 CARD_OFFSET = new Vector3(8, 0, -1);
    // private static Vector3 TRAIT_SCALE = new Vector3(0.5f, 0.5f, 1);
    private static Vector3 TRAIT_OFFSET = new Vector3(0, 0, -2);

    public GameObject DrawCard()
    {
        int randBackground = Rand.Next(Backgrounds.Count);
        int randChar = Rand.Next(Characters.Count);

        Tile background = Backgrounds[randBackground];
        Tile character = Characters[randChar];

        GameObject card = new GameObject();
        card.transform.SetParent(Grid.transform);
        card.transform.localScale = CARD_SCALE;
        card.transform.Translate(CARD_OFFSET);

        SpriteRenderer sr = card.AddComponent<SpriteRenderer>();
        sr.sprite = Frame.sprite;
        card.AddComponent<BoxCollider2D>();
        Card cardManager = card.AddComponent<Card>();

        GameObject trait1GO = new GameObject();
        trait1GO.transform.SetParent(card.transform);
        Trait t1 = trait1GO.AddComponent<Trait>();
        cardManager.traits.Add(t1);
        // trait1GO.transform.localScale = TRAIT_SCALE;
        trait1GO.transform.Translate(TRAIT_OFFSET+CARD_OFFSET);


        return card;
    }
}
