using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    private List<GameObject> Hand;
    public CardGenerator Generator;

    // Start is called before the first frame update
    void Start()
    {
        Hand = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hand.Count == 0)
        {
            Hand.Add(Generator.DrawCard());
        }
    }

    void LateUpdate()
    {

    }
}
