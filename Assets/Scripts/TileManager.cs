using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap BoardGrid;
    public Tilemap CharacterGrid;
    public Tilemap TraitGrid;

    public static TileManager tm;

    public void Start()
    {
        if (!tm)
        {
            tm = this;
        }
    }

    public void PlaceCard(Card card, Vector3Int gridPos)
    {
        // set card tile
        Tile cardTile = ScriptableObject.CreateInstance<Tile>();
        Sprite cardSprite = card.transform.GetComponent<SpriteRenderer>().sprite;
        cardTile.sprite = cardSprite;
        BoardGrid.SetTile(gridPos, cardTile);
        // Debug.Log("Set card " + cardTile + " to " + cardPos);

        // set background
        Vector3Int bgPos = new Vector3Int(gridPos.x, gridPos.y, 1);
        BoardGrid.SetTile(bgPos, card.bg);
        // Debug.Log("Set background " + card.bg + " to " + bgPos);

        // set character
        // Vector3Int charPos = new Vector3Int(gridPos.x, gridPos.y, 2);
        CharacterGrid.SetTile(gridPos, card.character);
        // Debug.Log("Set char " + card.character + " to " + charPos);

        // set traits
        for (int i = 0; i < card.traits.Count; i++)
        {
            Tile traitTile = Trait.CreateTraitTile(card.traits[i]);
            Vector3Int traitPos = new Vector3Int(gridPos.x, gridPos.y, i);
            TraitGrid.SetTile(traitPos, traitTile);
            // Debug.Log("Set trait " + traitTile + " to " + traitPos);
        }

        card.transform.gameObject.SetActive(false);
        GameManager.Hand.Remove(card.transform.gameObject);
        DatingCourt.Court[gridPos.x, gridPos.y] = card;
        DatingCourt.Evaluate();
    }
}
