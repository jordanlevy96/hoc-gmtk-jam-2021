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
            Debug.Log("You dragged a sprite onto " + gridPos);

            if (DatingCourt.Court[gridPos.x, gridPos.y])
            {
                Debug.Log("Tile taken!");
                return;
            }

            TileManager.tm.PlaceCard(this, gridPos);
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
