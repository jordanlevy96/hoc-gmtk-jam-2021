using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Card : MonoBehaviour
{
    private Tilemap grid;
    private Tile tile;

    private bool isDragging;

    public void Start()
    {
        grid = transform.parent.GetComponent<Tilemap>();
        tile = new Tile();
        tile.sprite = transform.GetComponent<SpriteRenderer>().sprite;
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
            Debug.Log("You dragged a sprite onto a tile!!!");
            grid.SetTile(gridPos, tile);
            Destroy(transform.gameObject);
            GameManager.Hand.Remove(transform.gameObject);
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
