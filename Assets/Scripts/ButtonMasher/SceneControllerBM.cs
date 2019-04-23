using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControllerBM : MonoBehaviour
{
    private int player1total;
    private int player2total;
    private int randomKey;
    private KeyCode player1Key;
    private KeyCode player2Key;
    private SpriteRenderer player1Button;
    private SpriteRenderer player2Button;
    private bool startGame;
    private bool endGame;

    public int goaltotal;
    public Text player1Text;
    public Text player2Text;
    public Text player1TotalText;
    public Text player2TotalText;
    public Text goalText;
    public Text winText;
    public Image winImage;
    public Sprite playerActive;
    public Sprite playerInactive;
    public GameObject player1Object;
    public GameObject player2Object;
    public float instructionTime;
    public Image instructionImage;
    public Text instructionText;
    public float endGameTime;
    public Text player1Name;
    public Text player2Name;

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

        player1Text.text = GetPlayer1Key();
        player2Text.text = GetPlayer2Key();

        player1Button = player1Object.GetComponent<SpriteRenderer>();
        player2Button = player2Object.GetComponent<SpriteRenderer>();
        SetPlayerSpriteActive();

    }

    private void Awake()
    {
        winImage.enabled = false;
        startGame = false;
        instructionImage.enabled = true;
        endGame = false;
        player1Name.text = GameControllerDOD.Player1Name;
        player2Name.text = GameControllerDOD.Player2Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        instructionTime -= Time.deltaTime;
        if(instructionTime<0)
        {
            startGame = true;
            instructionText.text = "";
            instructionImage.enabled = false;
        }
        if (startGame)
        {
            goalText.text = goaltotal.ToString();
            if (!GameOver())
            {
                if (Input.GetKeyDown(player1Key))
                {
                    player1total++;
                    player1TotalText.text = player1total.ToString();
                }
                if (Input.GetKeyDown(player2Key))
                {
                    player2total++;
                    player2TotalText.text = player2total.ToString();
                }
            }
            if (GameOver())
            {
                SetPlayerSpriteInactive();
            }
        }
        if(endGame)
        {
            endGameTime -= Time.deltaTime;
            if(endGameTime<0)
            {
                Application.LoadLevel("EndScreen");
            }
        }
    }

    private bool GameOver()
    {
        if(player1total>=goaltotal || player2total>=goaltotal)
        {
            if(player1total>=goaltotal)
            {
                winText.text = "Player 1 Wins!";
                winImage.enabled = true;
                GameControllerDOD.Player1Wins += 1;
                endGame = true;
            }
            else
            {
                winText.text = "Player 2 Wins!";
                winImage.enabled = true;
                GameControllerDOD.Player2Wins += 1;
                endGame = true;
            }
            return true;
        }
        return false;
    }

    public string GetPlayer1Key()
    {
        if(player1Key==KeyCode.W)
        {
            return "W";
        }
        else if (player1Key == KeyCode.A)
        {
            return "A";
        }
        else if (player1Key == KeyCode.S)
        {
            return "S";
        }
        else if (player1Key == KeyCode.D)
        {
            return "D";
        }

        //Default response
        return "W";
    }

    public string GetPlayer2Key()
    {
        if (player2Key == KeyCode.UpArrow)
        {
            return "UP";
        }
        else if (player2Key == KeyCode.LeftArrow)
        {
            return "LEFT";
        }
        else if (player2Key == KeyCode.DownArrow)
        {
            return "DOWN";
        }
        else if (player2Key == KeyCode.RightArrow)
        {
            return "RIGHT";
        }

        //Default response
        return "UP";
    }

    private void SetPlayerSpriteActive()
    {
        player1Button.sprite = playerActive;
        player2Button.sprite = playerActive;
    }

    private void SetPlayerSpriteInactive()
    {
        player1Button.sprite = playerInactive;
        player2Button.sprite = playerInactive;
    }
}
