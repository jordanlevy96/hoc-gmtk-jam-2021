using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject instructions;

    private void ToggleTutorial()
    {
        instructions.SetActive(!instructions.activeSelf);
        GameManager.ToggleDating();
    }

    void Awake()
    {
        instructions = GameObject.Find("instructions");
        instructions.SetActive(false);
    }

    public void OnMouseUp()
    {
        Debug.Log("Registered click");
        ToggleTutorial();
    } 
}
