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

    private static Vector3 CARD_SCALE = new Vector3(1.3f, 1.3f, 1);
    private static Vector3 CARD_OFFSET = new Vector3(8, 0, -1);
    private static Vector3 BACKGROUND_OFFSET = new Vector3(0, 0, -2);
    private static Vector3 BACKGROUND_SCALE = new Vector3(1, 1, 1); 
    private static Vector3 CHARACTER_OFFSET = new Vector3(0, 0, -3);
    private static Vector3 CHARACTER_SCALE = new Vector3(1, 1, 1);
    private static Vector3 TRAIT_OFFSET = new Vector3(-0.68f, 0.68f, -4);

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

        SpriteRenderer cardFrame = card.AddComponent<SpriteRenderer>();
        cardFrame.sprite = Frame.sprite;
        card.AddComponent<BoxCollider2D>();
        Card cardManager = card.AddComponent<Card>();

        GameObject bg = new GameObject("background");
        bg.transform.SetParent(card.transform);
        bg.transform.localScale = BACKGROUND_SCALE;
        bg.transform.Translate(CARD_OFFSET + BACKGROUND_OFFSET);
        SpriteRenderer bgSprite = bg.AddComponent<SpriteRenderer>();
        bgSprite.sprite = background.sprite;
        card.GetComponent<Card>().bg = background;

        GameObject ch = new GameObject("character");
        ch.transform.SetParent(card.transform);
        ch.transform.localScale = CHARACTER_SCALE;
        ch.transform.Translate(CARD_OFFSET + CHARACTER_OFFSET);
        SpriteRenderer chSprite = ch.AddComponent<SpriteRenderer>();
        chSprite.sprite = character.sprite;
        card.GetComponent<Card>().character = character;

        GameObject trait1GO = new GameObject("trait1");
        trait1GO.transform.SetParent(card.transform);
        Trait t1 = trait1GO.AddComponent<Trait>();
        cardManager.traits.Add(t1);
        // trait1GO.transform.localScale = TRAIT_SCALE;
        trait1GO.transform.Translate(TRAIT_OFFSET+CARD_OFFSET);


        return card;
    }
}
