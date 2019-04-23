﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlloerMM : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        GameControllerDOD.Player1Wins = 0;
        GameControllerDOD.Player2Wins = 0;
        GameControllerDOD.RoundNum = 1;
        GameControllerDOD.Player1Name = "Player 1";
        GameControllerDOD.Player2Name = "Player 2";
        Application.LoadLevel("CharacterSelect");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
