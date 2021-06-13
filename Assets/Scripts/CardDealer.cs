using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public CardGenerator Generator;
    private AudioSource dealCardSound;

    // Update is called once per frame
    public void Start() {
        dealCardSound = this.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (GameManager.Hand.Count == 0)
        {
            GameManager.Hand.Add(Generator.DrawCard());
            dealCardSound.Play();
        }
    }
}
