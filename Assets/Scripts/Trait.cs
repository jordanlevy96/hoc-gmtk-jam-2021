using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.Linq;

public enum TraitType
{
    HONEST,
    PATIENT,
    SMART,
    PROUD,
    LUSTFUL
}

public class Trait : MonoBehaviour
{
    // public static Dictionary<TraitType, Color> TraitColors = new Dictionary<TraitType, Color>
    // {
    //     {TraitType.HONEST, new Color(180, 0, 255)},
    //     {TraitType.PATIENT, new Color(0, 0, 255)},
    //     {TraitType.SMART, new Color(0, 255, 0)},
    //     {TraitType.PROUD, new Color(255, 255, 0)},
    //     {TraitType.LUSTFUL, new Color(255, 0, 0)},
    // };

    public static Dictionary<TraitType, string> TraitPaths = new Dictionary<TraitType, string>
    {
        {TraitType.HONEST, "Traits/Honest"},
        {TraitType.PATIENT, "Traits/Patient"},
        {TraitType.SMART, "Traits/Smart"},
        {TraitType.PROUD, "Traits/Proud"},
        {TraitType.LUSTFUL, "Traits/Lustful"}
    };

    public static Dictionary<TraitType, int[]> TraitMatches = new Dictionary<TraitType, int[]>
    {
        {TraitType.HONEST, new int[] {(int) TraitType.LUSTFUL, (int) TraitType.PATIENT}},
        {TraitType.PATIENT, new int[] {(int) TraitType.HONEST, (int) TraitType.SMART}},
        {TraitType.SMART, new int[] {(int) TraitType.PATIENT, (int) TraitType.PROUD}},
        {TraitType.PROUD, new int[] {(int) TraitType.LUSTFUL, (int) TraitType.SMART}},
        {TraitType.LUSTFUL, new int[] {(int) TraitType.PROUD, (int) TraitType.HONEST}}
    };

    public static int CompareTraits(Trait t1, Trait t2)
    {
        // Debug.Log("Comparing " + t1.trait + " and " + t2.trait);
        if (t1.trait == t2.trait)
        {
            return GameManager.gm.SameMatchScore;
        }
        else if (TraitMatches[t1.trait].Contains((int) t2.trait))
        {
            return GameManager.gm.CloseMatchScore;
        }
        else
        {
            return 0;
        }
    }

    private TraitType trait;
    private static System.Random rand = new System.Random();

    void Awake()
    {
        TraitType[] traits = (TraitType[])System.Enum.GetValues(typeof(TraitType));
        int randi = rand.Next(traits.Length);
        trait = (TraitType)traits.GetValue(randi);
    }

    public Sprite GetTraitSprite()
    {
        return (Sprite)Resources.Load<Sprite>(TraitPaths[trait]);
    }

    public static Tile CreateTraitTile(Trait t)
    {
        Tile traitTile = ScriptableObject.CreateInstance<Tile>();
        Sprite traitSprite = t.transform.GetComponent<SpriteRenderer>().sprite;
        traitTile.sprite = traitSprite;

        return traitTile;
    }
}
