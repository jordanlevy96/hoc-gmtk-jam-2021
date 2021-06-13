using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public CardGenerator Generator;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Hand.Count == 0)
        {
            GameManager.Hand.Add(Generator.DrawCard());
        }
    }
}
