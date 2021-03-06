using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Card : MonoBehaviour
{
    private Tilemap grid;
    private bool isDragging;
    public List<Trait> traits = new List<Trait>();
    public Tile bg;
    public Tile character;
    public Bond bond;
    public Vector3Int gridPos;

    public void Start()
    {
        // grid = transform.parent.GetComponent<Tilemap>();
        grid = TileManager.tm.BoardGrid;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        gridPos = grid.WorldToCell(transform.position);

        if (grid.HasTile(gridPos))
        {
            if (DatingCourt.Court[gridPos.x, gridPos.y])
            {
                Debug.Log("Tile taken!");
                return;
            }

            grid.SetTile(gridPos, null);
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

    public Bond.BondLevel GetBondLevel()
    {
        if (!bond)
        {
            return Bond.BondLevel.ZERO;
        }
        else
        {
            return bond.level;
        }
    }

    public static int CompareCards(Card c1, Card c2)
    {
        int total = 0;
        int curr = 0;
        Bond b = null;

        if ((int) c1.GetBondLevel() + (int) c2.GetBondLevel() < 2)
        {
            GameObject newBond = new GameObject("bond");
            b = newBond.AddComponent<Bond>();
            c1.bond = b;
            b.bonders.Add(c1);
            c2.bond = b;
            b.bonders.Add(c2);
            b.CalculateLocation();
        }

        foreach (Trait t1 in c1.traits)
        {
            foreach (Trait t2 in c2.traits)
            {
                curr = Trait.CompareTraits(t1, t2, b);
                total += curr;
            }
        }
        return total;
    }
}
