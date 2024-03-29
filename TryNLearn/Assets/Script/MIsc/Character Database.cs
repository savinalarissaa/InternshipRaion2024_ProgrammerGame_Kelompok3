using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterSelection[] character;
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public CharacterSelection GetCharacter(int index)
    {
        return character[index];
    }
}
