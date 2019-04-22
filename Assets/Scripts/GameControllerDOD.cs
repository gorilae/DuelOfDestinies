using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerDOD : MonoBehaviour
{
    private static int player1wins, player2wins;
    private static Sprite player1character, player2character;

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
            return player2character;
        }
        set
        {
            player2character = value;
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
}
