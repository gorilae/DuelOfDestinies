﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControllerCS : MonoBehaviour
{
    private int player1Character;
    private int player2Character;
    //False if player 2 selecting, true if player 1 selecting
    private bool player1Selection; 

    public Image background;
    public Image player1Image;
    public Image player2Image;
    public Image player1Label;
    public Image player2Label;
    public Button player1Selector;
    public Button player2Selector;
    public Button charactersConfirmed;
    public Sprite player1Background;
    public Sprite player2Background;
    public Sprite buttonActive;
    public Sprite buttonInactive;
    public Sprite doctor;
    public Sprite goki;
    public Sprite stick;
    public Sprite btm;
    public Sprite pam;
    public Sprite tsuyoi;
    public Text player1Name;
    public Text player2Name;

    //Assume 0=Doctor, 1=Goki, 2=STICK, 3=BTM, 4=PAM, 5=Tsuyoi
    public void SetPlayerCharacter(int character)
    {
        if(player1Selection)
        {
            player1Character = character;
            player1Image.sprite = GetCharacterSprite(character);
            player1Name.text = GetCharacterName(character);
        }
        else
        {
            player2Character = character;
            player2Image.sprite = GetCharacterSprite(character);
            player2Name.text = GetCharacterName(character);
        }
    }

    public void ChangePlayerSelection()
    {
        player1Selection = !(player1Selection);
    }

    public void CharactersConfirmed()
    {
        GameControllerDOD.Player1Character = player1Image.sprite;
        GameControllerDOD.Player2Character = player2Image.sprite;
        GameControllerDOD.RoundNum = 1;
        GameControllerDOD.RoundGame = "SS";
        GameControllerDOD.Player1Name = GetCharacterName(player1Character);
        GameControllerDOD.Player2Name = GetCharacterName(player2Character);
        Application.LoadLevel("CharacterFight");
    }

    private Sprite GetCharacterSprite(int character)
    {
        if(character == 0)
        {
            return doctor;
        }
        if(character == 1)
        {
            return goki;
        }
        if(character == 2)
        {
            return stick;
        }
        if(character == 3)
        {
            return btm;
        }
        if(character == 4)
        {
            return pam;
        }
        else
        {
            return tsuyoi;
        }
    }

    private string GetCharacterName(int character)
    {
        if (character == 0)
        {
            return "Doctor";
        }
        if (character == 1)
        {
            return "Goki";
        }
        if (character == 2)
        {
            return "S.T.I.C.K.";
        }
        if (character == 3)
        {
            return "B.T.M.";
        }
        if (character == 4)
        {
            return "P.A.M.";
        }
        else
        {
            return "Tsuyoi";
        }
    }

    private void Start()
    {
        player1Selection = true;
        background.sprite = player1Background;
        player1Character = 99;
        player2Character = 99;
    }
    private void Update()
    {
        if(player1Selection)
        {
            background.sprite = player1Background;
            player2Label.sprite = buttonInactive;
            player1Label.sprite = buttonActive;
            player1Selector.image.sprite = buttonActive;
            player2Selector.image.sprite = buttonInactive;
            player1Selector.enabled = false;
            player2Selector.enabled = true;
        }
        else
        {
            background.sprite = player2Background;
            player2Label.sprite = buttonActive;
            player1Label.sprite = buttonInactive;
            player1Selector.image.sprite = buttonInactive;
            player2Selector.image.sprite = buttonActive;
            player1Selector.enabled = true;
            player2Selector.enabled = false;
        }

        if(player1Character!=99)
        {
            if(player2Character!=99)
            {
                charactersConfirmed.enabled = true;
            }
            else
            {
                charactersConfirmed.enabled = false;
            }
        }
        else
        {
            charactersConfirmed.enabled = false;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
