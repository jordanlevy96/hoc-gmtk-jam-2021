using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Card : MonoBehaviour
{
    public Tilemap field;
    public Tile tile;
    private bool isDragging;

    void Start()
    {
        Debug.Log("New Card!");
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        Vector3Int gridPos = field.WorldToCell(transform.position);
        
        
        if (field.HasTile(gridPos))
        {
            Debug.Log("You dragged a sprite onto a tile!!!");
            field.SetTile(gridPos, tile);
            Destroy(transform.gameObject);
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
