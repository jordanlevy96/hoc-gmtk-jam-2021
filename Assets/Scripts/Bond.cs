using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
