using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoice : MonoBehaviour
{
    public Image player1Character;
    public Image player2Character;
    public Text player1Wins;
    public Text player2Wins;
    public Text nextRoundNum;
    public Text nextRoundGame;
    public float waitTime;
    public Text player1Name;
    public Text player2Name;

    void Start()
    {
        player1Character.sprite = GameControllerDOD.Player1Character;
        player2Character.sprite = GameControllerDOD.Player2Character;
        player1Wins.text = GameControllerDOD.Player1Wins.ToString();
        player2Wins.text = GameControllerDOD.Player2Wins.ToString();
        nextRoundNum.text = "#" + GameControllerDOD.RoundNum.ToString();
        nextRoundGame.text = GameControllerDOD.RoundGame;
        player1Name.text = GameControllerDOD.Player1Name;
        player2Name.text = GameControllerDOD.Player2Name;
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if(GameControllerDOD.Player1Wins>=2 || GameControllerDOD.Player2Wins>=2)
        {
            Application.LoadLevel("EndScene");
        }
        if(waitTime<0)
        {
            if (GameControllerDOD.RoundGame.Equals("TTT"))
            {
                Application.LoadLevel("TicTacToe");
            }
            if (GameControllerDOD.RoundGame.Equals("SS"))
            {
                Application.LoadLevel("SimonSays");
            }
            if(GameControllerDOD.RoundGame.Equals("BM"))
            {
                Application.LoadLevel("ButtonMasher");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
