using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;


public class GameControllerTTT : MonoBehaviour
{

    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public Image player1Character;
    public Image player2Character;
    public float endGameTime;
    public Text player1Name;
    public Text player2Name;

    private string playerSide;
    private int moveCount;
    private int[] recordedWins;
    private int roundNum;
    private bool endGame;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        SetBoardInteractable(true);
        endGame = false;
        player1Character.sprite = GameControllerDOD.Player1Character;
        player2Character.sprite = GameControllerDOD.Player2Character;
        player1Name.text = GameControllerDOD.Player1Name;
        player2Name.text = GameControllerDOD.Player2Name;

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

        recordedWins = new int[2];
        recordedWins[0] = 0;
        recordedWins[1] = 0;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (endGame)
        {
            endGameTime -= Time.deltaTime;
            if(endGameTime<0)
            {
                if(recordedWins[0].Equals(2))
                {
                    GameControllerDOD.Player1Wins += 1;
                    GameControllerDOD.RoundNum = 3;
                    GameControllerDOD.RoundGame = "BM";
                }
                else
                {
                    GameControllerDOD.Player2Wins += 1;
                    GameControllerDOD.RoundNum = 3;
                    GameControllerDOD.RoundGame = "BM";
                }
                Application.LoadLevel("CharacterFight");
            }
        }
    }

    public void RestartGame()
    {
        playerSide = "O";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpaceTTT>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        ChangeSides();
        if (moveCount >= 9)
        {
            SetGameOverText("It's a draw!");
            RestartGame();
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver()
    {
        SetGameOverText(playerSide + " Wins Round " + roundNum+"!");
        if (playerSide == "X")
        {
            recordedWins[0]++;
        }
        if (playerSide == "O")
        {
            recordedWins[1]++;
        }
        if (recordedWins[0].Equals(2))
        {
            SetBoardInteractable(false);
            SetGameOverText("X Wins!");
            endGame = true;
            return;
        }
        if (recordedWins[1].Equals(2))
        {
            SetBoardInteractable(false);
            SetGameOverText("O Wins!");
            endGame = true;
            return;
        }
        RestartGame();
    }

    void SetGameOverText(string text)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = text;
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
