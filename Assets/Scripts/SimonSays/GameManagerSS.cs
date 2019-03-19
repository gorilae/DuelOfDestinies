using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSS : MonoBehaviour
{
    public SpriteRenderer[] colors;
    public float stayLit;
    public float waitBetweenLights;
    public List<int> activeSequence;
    public GameObject wrongMark;
    public float wrongInput;

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

    // Start is called before the first frame update
    void Start()
    {
        wrongMark.SetActive(false);
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
                activeSequence.Clear();
                gameActive = false;
            }
        }
    }

}
