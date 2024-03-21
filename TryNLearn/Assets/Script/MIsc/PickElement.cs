using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickElement : MonoBehaviour
{
        public PlayerController.CharacterType characterType; // Assign this in the Unity Editor

        public void OnClick()
        {
            PlayerController.Instance.SetCurrentCharacter(characterType);
        }
    
}
