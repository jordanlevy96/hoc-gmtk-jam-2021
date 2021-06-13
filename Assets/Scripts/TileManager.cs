using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap BoardGrid;
    public Tilemap CharacterGrid;
    public Tilemap TraitGrid;
    public Tilemap SecondaryTraits;

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
        GameManager.TurnsTaken += 1;
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
        Tile traitTile = Trait.CreateTraitTile(card.traits[0]);
        Vector3Int traitPos = new Vector3Int(gridPos.x, gridPos.y, 1);
        TraitGrid.SetTile(traitPos, traitTile);

        Tile secondaryTrait = Trait.CreateTraitTile(card.traits[1]);
        Vector3Int trait2Pos = new Vector3Int(gridPos.x, gridPos.y, 2);
        SecondaryTraits.SetTile(trait2Pos, secondaryTrait);

        card.transform.gameObject.SetActive(false);
        GameManager.Hand.Remove(card.transform.gameObject);
        DatingCourt.Court[gridPos.x, gridPos.y] = card;

        if (!GameManager.AITurnActive)
        {
            // only calculate new score on player turn
            DatingCourt.EvaluateScore(gridPos.x, gridPos.y);
        }
    }
}
