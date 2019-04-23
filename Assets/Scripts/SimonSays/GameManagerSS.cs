using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSS : MonoBehaviour
{
    public SpriteRenderer[] colors;
    public float stayLit;
    public float waitBetweenLights;
    public List<int> activeSequence;
    public GameObject wrongMark;
    public float wrongInput;
    public Image player1Background;
    public Image player2Background;
    public Image player1Title;
    public Image player2Title;
    public Image player1Character;
    public Image player2Character;
    public Sprite playerActive;
    public Sprite playerInActive;
    public Button startButton;
    public Image winImage;
    public Text winText;

    private int colorSelect;
    private float stayLitCounter;
    private float waitBetweenCounter;
    private bool shouldBeLit;
    private bool shouldBeDark;
    private int positionInSquence;
    private bool gameActive;
    private int inputInSequence;
    private bool inputFalse;
    private float wrongInputCounter;
    private int player1Total;
    private int player2Total;
    private bool player1Active;

    // Start is called before the first frame update
    void Start()
    {
        wrongMark.SetActive(false);
        player1Active = true;
        player1Total = 0;
        player2Total = 0;
        startButton.enabled = true;
        winImage.enabled = false;
        SetPlayerEnabled(1);
        player1Character.sprite = GameControllerDOD.Player1Character;
        player2Character.sprite = GameControllerDOD.Player2Character;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;
            if(stayLitCounter<0)
            {
                colors[activeSequence[positionInSquence]].color = new Color(colors[activeSequence[positionInSquence]].color.r, colors[activeSequence[positionInSquence]].color.g, colors[activeSequence[positionInSquence]].color.b, 0.5f);
                shouldBeLit = false;

                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                positionInSquence++;
            }
        }
        if(shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;
            if(positionInSquence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else
            {
                if(waitBetweenCounter<0)
                {
                    colors[activeSequence[positionInSquence]].color = new Color(colors[activeSequence[positionInSquence]].color.r, colors[activeSequence[positionInSquence]].color.g, colors[activeSequence[positionInSquence]].color.b, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }
        if(inputFalse)
        {
            wrongInputCounter -= Time.deltaTime;
            if(!(wrongInputCounter<0))
            {
                wrongMark.SetActive(true);
            }
            else
            {
                inputFalse = false;
                wrongMark.SetActive(false);
                if(player1Active)
                {
                    player1Active = false;
                    player1Total = activeSequence.Count;
                    SetPlayerEnabled(2);
                }
                else
                {
                    player2Total = activeSequence.Count;
                    EndGame();
                }
                activeSequence.Clear();
            }
        }
    }

    public void StartGame()
    {
        activeSequence.Clear();

        positionInSquence = 0;
        inputInSequence = 0;

        colorSelect = Random.Range(0, colors.Length);

        activeSequence.Add(colorSelect);

        colors[activeSequence[positionInSquence]].color = new Color(colors[activeSequence[positionInSquence]].color.r, colors[activeSequence[positionInSquence]].color.g, colors[activeSequence[positionInSquence]].color.b, 1f);

        stayLitCounter = stayLit;
        wrongInputCounter = wrongInput;
        shouldBeLit = true;
    }

    public void ColorPressed(int buttonNum)
    {
        if (gameActive)
        {

            if (activeSequence[inputInSequence] == buttonNum)
            {
                Debug.Log("Correct.");
                inputInSequence++;
                if(inputInSequence >= activeSequence.Count)
                {
                    positionInSquence = 0;
                    inputInSequence = 0;

                    colorSelect = Random.Range(0, colors.Length);

                    activeSequence.Add(colorSelect);

                    colors[activeSequence[positionInSquence]].color = new Color(colors[activeSequence[positionInSquence]].color.r, colors[activeSequence[positionInSquence]].color.g, colors[activeSequence[positionInSquence]].color.b, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    gameActive = false;
                }
            }
            else
            {
                Debug.Log("Wrong.");
                inputFalse = true;
                shouldBeDark = false;
                shouldBeLit = false;
                gameActive = false;
            }
        }
    }


    private void EndGame()
    {
        if(player1Total>player2Total)
        {
            startButton.enabled = false;
            winText.text = "Player 1 Wins!";
            winImage.enabled = true;
            SetPlayerEnabled(1);
            GameControllerDOD.Player1Wins += 1;
        }
        else if(player2Total>player1Total)
        {
            startButton.enabled = false;
            winText.text = "Player 2 Wins!";
            winImage.enabled = true;
            SetPlayerEnabled(2);
            GameControllerDOD.Player2Wins += 1;
        }
        else
        {
            player1Total = 0;
            player2Total = 0;
            player1Active = true;
            SetPlayerEnabled(1);
        }
    }

    private void SetPlayerEnabled(int playernum)
    {
        if(playernum == 1)
        {
            player1Background.sprite = playerActive;
            player1Title.sprite = playerActive;
            player2Background.sprite = playerInActive;
            player2Title.sprite = playerInActive;
        }
        else
        {
            player2Background.sprite = playerActive;
            player2Title.sprite = playerActive;
            player1Background.sprite = playerInActive;
            player1Title.sprite = playerInActive;
        }
    }
}
