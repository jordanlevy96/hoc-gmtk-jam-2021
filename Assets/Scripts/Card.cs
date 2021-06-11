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

        Vector3Int tilePos = Vector3Int.FloorToInt(transform.position);
        // SpriteRenderer sprite = (SpriteRenderer)transform.gameObject.GetComponent(typeof(SpriteRenderer));
        // TileBase tile = (TileBase)ScriptableObject.CreateInstance(sprite.sprite);
        
        if (field.HasTile(tilePos))
        {
            Debug.Log("You dragged a sprite onto a tile!!!");
            Vector3Int gridPos = field.WorldToCell(tilePos);
            field.SetTile(gridPos, tile);
            Destroy(transform.gameObject);
        }
        Debug.Log(tilePos);
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
