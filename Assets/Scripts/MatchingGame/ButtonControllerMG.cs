using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerMG : MonoBehaviour
{

    private SpriteRenderer thisSprite;
    private GameManagerMG gameManager;
    public Color buttonColor;
    private bool colored;

    public int buttonNumber;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManagerMG>();
        colored = false;
        thisSprite.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        ChangeColoredState();
    }

    private void OnMouseUp()
    {
        ChangeColoredState();
        //gameManager.ColorPressed(buttonNumber);
    }

    public void SetButtonColor(Color newColor)
    {
        buttonColor = newColor;
    }

    public void ChangeColoredState()
    {
        if(colored)
        {
            thisSprite.color = new Color(1f, 1f, 1f, 1f);
            colored = false;
        }
        else
        {
            thisSprite.color = buttonColor;
            colored = true;
        }
    }
}
