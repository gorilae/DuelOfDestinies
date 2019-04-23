using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerDOD : MonoBehaviour
{
    private static int player1wins, player2wins, player1charid, player2charid, roundNum;
    private static Sprite player1character, player2character;
    private static string roundGame, player1Name, player2Name;
    public static int Player1Wins
    {
        get
        {
            return player1wins;
        }
        set
        {
            player1wins = value;
        }
    }

    public static int Player2Wins
    {
        get
        {
            return player2wins;
        }
        set
        {
            player2wins = value;
        }
    }

    public static Sprite Player1Character
    {
        get
        {
            return player1character;
        }
        set
        {
            player1character = value;
        }
    }

    public static Sprite Player2Character
    {
        get
        {
            return player2character;
        }
        set
        {
            player2character = value;
        }
    }

    public static int Player1ID
    {
        get
        {
            return player1charid;
        }
        set
        {
            player1charid = value;
        }
    }

    public static int Player2ID
    {
        get
        {
            return player2charid;
        }
        set
        {
            player2charid = value;
        }
    }

    public static int RoundNum
    {
        get
        {
            return roundNum;
        }
        set
        {
            roundNum = value;
        }
    }

    public static string RoundGame
    {
        get
        {
            return roundGame;
        }
        set
        {
            roundGame = value;
        }
    }

    public static string Player1Name
    {
        get
        {
            return player1Name;
        }
        set
        {
            player1Name = value;
        }
    }

    public static string Player2Name
    {
        get
        {
            return player2Name;
        }
        set
        {
            player2Name = value;
        }
    }
}
