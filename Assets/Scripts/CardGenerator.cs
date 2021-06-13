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

    private static Vector3 CARD_SCALE = new Vector3(5.2f, 5.2f, 1);
    private static Vector3 CARD_OFFSET = new Vector3(8, 0, -5);
    private static Vector3 BACKGROUND_OFFSET = new Vector3(0, 0, 0);
    private static Vector3 BACKGROUND_SCALE = new Vector3(1, 1, -1); 
    private static Vector3 CHARACTER_OFFSET = new Vector3(0, 0, -2);
    private static Vector3 CHARACTER_SCALE = new Vector3(1, 1, 1);
    private static Vector3 TRAIT_OFFSET = new Vector3(-0.68f, 0.68f, -3);
    private static Vector3 TRAIT_SCALE = new Vector3(1, 1, 1);
    private static int CARD_SORTING = 10;

    public GameObject DrawCard()
    {
        int randBackground = Rand.Next(Backgrounds.Count);
        int randChar = Rand.Next(Characters.Count);

        Tile background = Backgrounds[randBackground];
        Tile character = Characters[randChar];

        GameObject cardGO = new GameObject();
        // cardGO.transform.SetParent(Grid.transform);
        cardGO.transform.localScale = CARD_SCALE;
        cardGO.transform.Translate(CARD_OFFSET);

        SpriteRenderer cardFrame = cardGO.AddComponent<SpriteRenderer>();
        cardFrame.sprite = Frame.sprite;
        cardFrame.sortingOrder = CARD_SORTING;
        cardGO.AddComponent<BoxCollider2D>();
        Card card = cardGO.AddComponent<Card>();

        GameObject bg = new GameObject("background");
        bg.transform.SetParent(cardGO.transform);
        bg.transform.localScale = BACKGROUND_SCALE;
        bg.transform.Translate(CARD_OFFSET + BACKGROUND_OFFSET);
        SpriteRenderer bgSprite = bg.AddComponent<SpriteRenderer>();
        bgSprite.sprite = background.sprite;
        bgSprite.sortingOrder = CARD_SORTING;

        cardGO.GetComponent<Card>().bg = background;

        GameObject ch = new GameObject("character");
        ch.transform.SetParent(cardGO.transform);
        ch.transform.localScale = CHARACTER_SCALE;
        ch.transform.Translate(CARD_OFFSET + CHARACTER_OFFSET);
        SpriteRenderer chSprite = ch.AddComponent<SpriteRenderer>();
        chSprite.sprite = character.sprite;
        chSprite.sortingOrder = CARD_SORTING;
        cardGO.GetComponent<Card>().character = character;

        GameObject trait1GO = new GameObject("trait1");
        trait1GO.transform.SetParent(cardGO.transform);
        Trait t1 = trait1GO.AddComponent<Trait>();
        card.traits.Add(t1);
        SpriteRenderer t1Sprite = trait1GO.AddComponent<SpriteRenderer>();
        t1Sprite.sprite = t1.GetTraitSprite();
        t1Sprite.sortingOrder = CARD_SORTING;
        trait1GO.transform.localScale = TRAIT_SCALE;
        trait1GO.transform.Translate(TRAIT_OFFSET+CARD_OFFSET);


        return cardGO;
    }
}
