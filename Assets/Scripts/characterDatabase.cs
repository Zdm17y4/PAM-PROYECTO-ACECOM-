using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class characterDatabase : ScriptableObject
{
    public Character[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public Character GetCharacter(int index)
    {
        return character[index];
    }

}
