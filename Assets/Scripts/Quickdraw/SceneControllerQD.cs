using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerQD : MonoBehaviour
{
    public Sprite readySprite;
    public Sprite goSprite;

    private int time = Random.Range(3, 20);
    private bool ready = false;

    private bool player1win = false;
    private bool player2win = false;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = readySprite;
        MyMethod();
    }
    
    void Update()
    {
        if (ready == true && Input.GetKeyDown(KeyCode.A))
        {
            player1win = true;
        }
        if (ready == true && Input.GetKeyDown(KeyCode.L))
        {
            player2win = true;
        }
        if (ready == false && Input.GetKeyDown(KeyCode.A))
        {
            player2win = true;
        }
        if (ready == false && Input.GetKeyDown(KeyCode.L))
        {
            player1win = true;
        }
    }

    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<SpriteRenderer>().sprite = goSprite;
        ready = true;
    }
}
