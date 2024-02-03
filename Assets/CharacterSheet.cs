using UnityEngine;
using System;

public class CharacterSheet : MonoBehaviour
{
    // Variables to be set in the Unity Editor
    public string characterName;
    public int proficiencyBonus;
    public bool usingFinesseWeapon;
    public int strengthModifier;
    public int dexterityModifier;

    // This method is called when the GameObject the script is attached to becomes enabled and active
    void Start()
    {
        // Determine which modifier to use based on finesse weapon usage
        int hitModifier;
        int mainModifier = usingFinesseWeapon ? Math.Max(strengthModifier, dexterityModifier) : strengthModifier;

        // Calculate hit modifier by adding proficiency bonus to the main modifier
        hitModifier = mainModifier >= 0 ? mainModifier + proficiencyBonus : mainModifier;

        // Print out the hit modifier with a '+' prefix for positive modifiers
        Debug.Log(characterName + "'s hit modifier is " + (hitModifier >= 0 ? "+" : "") + hitModifier);

        // Simulate enemy AC and D20 roll
        int enemyAC = UnityEngine.Random.Range(10, 21);
        int d20Roll = UnityEngine.Random.Range(1, 21);
        int totalAttackRoll = d20Roll + hitModifier;

        // Print out the enemy's AC and the result of the D20 roll
        Debug.Log("Enemy AC is " + enemyAC);
        Debug.Log(characterName + " rolled a " + d20Roll);

        // Determine if the attack hits the enemy based on total attack roll and enemy AC
        if (totalAttackRoll >= enemyAC)
        {
            Debug.Log("Enemy is hit!");
        }
        else
        {
            Debug.Log("Enemy evades the attack!");
        }
    }
}
