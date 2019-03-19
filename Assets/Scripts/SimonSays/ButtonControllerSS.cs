using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerSS : MonoBehaviour
{

    private SpriteRenderer thisSprite;
    private GameManagerSS gameManager;

    public int buttonNumber;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManagerSS>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        thisSprite.color = new Color(thisSprite.color.r, thisSprite.color.g, thisSprite.color.b, 1f);
    }

    private void OnMouseUp()
    {
        thisSprite.color = new Color(thisSprite.color.r, thisSprite.color.g, thisSprite.color.b, 0.5f);
        gameManager.ColorPressed(buttonNumber);
    }
}
