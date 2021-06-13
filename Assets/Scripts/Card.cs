using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Card : MonoBehaviour
{
    public static int CompareCards(Card c1, Card c2)
    {
        int total = 0;
        int curr = 0;
        foreach (Trait t1 in c1.traits)
        {
            foreach (Trait t2 in c2.traits)
            {
                curr = Trait.CompareTraits(t1, t2);
                total += curr;
            }
        }
        return total;
    }

    private Tilemap grid;
    private bool isDragging;
    public List<Trait> traits = new List<Trait>();
    public Tile bg;
    public Tile character;

    public void Start()
    {
        grid = transform.parent.GetComponent<Tilemap>();
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        Vector3Int gridPos = grid.WorldToCell(transform.position);

        if (grid.HasTile(gridPos))
        {
            if (DatingCourt.Court[gridPos.x, gridPos.y])
            {
                Debug.Log("Tile taken!");
                return;
            }

            Debug.Log("You dragged a sprite onto " + gridPos);

            Tile cardTile = ScriptableObject.CreateInstance<Tile>();
            Sprite cardSprite = transform.GetComponent<SpriteRenderer>().sprite;
            cardTile.sprite = cardSprite;
            Vector3Int cardPos = new Vector3Int(gridPos.x, gridPos.y, 0);
            grid.SetTile(cardPos, cardTile);
            Debug.Log("Set card " + cardTile + " to " + cardPos);

            Vector3Int bgPos = new Vector3Int(gridPos.x, gridPos.y, 10);
            grid.SetTile(bgPos, bg);
            Debug.Log("Set background " + bg + " to " + bgPos);

            Vector3Int charPos = new Vector3Int(gridPos.x, gridPos.y, 20);
            grid.SetTile(charPos, character);
            Debug.Log("Set char " + character + " to " + charPos);

            for (int i = 0; i < traits.Count; i++)
            {
                Tile traitTile = Trait.CreateTraitTile(traits[i]);
                Vector3Int traitPos = new Vector3Int(gridPos.x, gridPos.y, i*10 + 30);
                grid.SetTile(traitPos, traitTile);
                Debug.Log("Set trait " + traitTile + " to " + traitPos);
            }

            transform.gameObject.SetActive(false);
            GameManager.Hand.Remove(transform.gameObject);
            DatingCourt.Court[gridPos.x, gridPos.y] = this;
            DatingCourt.Evaluate();
            grid.RefreshAllTiles();
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }

    }
}
