using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridSpaceTTT : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private GameControllerTTT gameController;

    public void SetGameControllerReference(GameControllerTTT controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide() ;
        button.interactable = false;
        gameController.EndTurn();
    }
}
