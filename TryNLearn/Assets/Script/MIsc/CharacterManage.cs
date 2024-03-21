using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManage : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDatabase.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
    }

    public void UpdateCharacter(int selectedOption)
    {
        CharacterSelection character = characterDatabase.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }
}
