using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControllerES : MonoBehaviour
{
    public Text winText;
    public Image WinImage;

    void Start()
    {
        if(GameControllerDOD.Player1Wins==2)
        {
            WinImage.sprite = GameControllerDOD.Player1Character;
            winText.text = GameControllerDOD.Player1Name + " Wins!";
        }
        else
        {
            WinImage.sprite = GameControllerDOD.Player2Character;
            winText.text = GameControllerDOD.Player2Name + " Wins!";
        }
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void Rematch()
    {
        Application.LoadLevel("CharacterSelect");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
