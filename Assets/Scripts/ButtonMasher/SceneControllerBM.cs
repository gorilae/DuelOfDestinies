using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerBM : MonoBehaviour
{
    private int player1total;
    private int player2total;
    private int randomKey;
    private KeyCode player1Key;
    private KeyCode player2Key;

    public int goaltotal;

    // Start is called before the first frame update
    void Start()
    {
        player1total = 0;
        player2total = 0;
        randomKey = Random.Range(0, 4);

        //Default Key Presser
        player1Key = KeyCode.W;
        player2Key = KeyCode.UpArrow;

        //Randomness with Button Mashed Key
        if(randomKey==1)
        {
            player1Key = KeyCode.A;
            player2Key = KeyCode.LeftArrow;
        }
        if (randomKey == 2)
        {
            player1Key = KeyCode.S;
            player2Key = KeyCode.DownArrow;
        }
        if (randomKey == 3)
        {
            player1Key = KeyCode.D;
            player2Key = KeyCode.RightArrow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOver())
        {
            if(Input.GetKeyDown(player1Key))
            {
                player1total++;
            }
            if(Input.GetKeyDown(player2Key))
            {
                player2total++;
            }
        }
    }

    public bool GameOver()
    {
        if(player1total==goaltotal || player2total==goaltotal)
        {
            return true;
        }
        return false;
    }

    public string GetPlayer1Key()
    {
        if(player1Key==KeyCode.W)
        {
            return "w";
        }
        else if (player1Key == KeyCode.A)
        {
            return "a";
        }
        else if (player1Key == KeyCode.S)
        {
            return "s";
        }
        else if (player1Key == KeyCode.D)
        {
            return "d";
        }

        //Default response
        return "w";
    }

    public string GetPlayer2Key()
    {
        if (player2Key == KeyCode.UpArrow)
        {
            return "up";
        }
        else if (player2Key == KeyCode.LeftArrow)
        {
            return "left";
        }
        else if (player2Key == KeyCode.DownArrow)
        {
            return "down";
        }
        else if (player2Key == KeyCode.RightArrow)
        {
            return "right";
        }

        //Default response
        return "up";
    }
}
}
}
}
