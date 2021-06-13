using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bond : MonoBehaviour
{
    public enum BondLevel
    {
        ZERO,
        ONE,
        TWO
    }
    
    public BondLevel level;
    public List<Card> bonders;

    void Awake()
    {
        Sprite heart = (Sprite)Resources.Load<Sprite>("heart");
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = heart;
        bonders = new List<Card>();
    }

    public void CalculateLocation()
    {
        // float x = bonders[0].transform.position.x;
        // float y = bonders[0].transform.position.y;

        // x += bonders[1].transform.position.x; 
        // y += bonders[1].transform.position.y;

        // x = x/2;
        // y = y/2;

        // Vector3Int t = new Vector3Int(Mathf.RoundToInt(x), Mathf.RoundToInt(y), 0);
        Tilemap grid = GameObject.Find("FieldMap").GetComponent<Tilemap>();
        // Vector3 translate = grid.CellToWorld(t);
        Vector3 pos1 = (Vector3)bonders[0].gridPos;
        Vector3 pos2 = (Vector3)bonders[1].gridPos;
        // Vector3 translate = Vector3.Cross(pos1, pos2);
        Vector3 translate = new Vector3((pos1.x+pos2.x)/2, (pos1.y+pos2.y)/2, 0);
        Debug.Log(pos1);
        Debug.Log(pos2);
        Debug.Log(translate);
        Vector3 t = grid.CellToWorld(Vector3Int.RoundToInt(translate));
        Debug.Log(t);

        transform.localScale = new Vector3(4, 4, 1);
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sortingOrder = 5;
        transform.Translate(t);
    }
}
