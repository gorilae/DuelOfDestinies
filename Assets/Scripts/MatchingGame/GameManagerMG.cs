using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMG : MonoBehaviour
{
    public SpriteRenderer[] colors;
    public float stayLit;

    private float stayLitCounter;
    private int[] colorLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        stayLitCounter = stayLit;
        RandomlyAssignColors();
    }

    public void ColorPressed(int buttonNum)
    {
        
    }

    void RandomlyAssignColors()
    {
        
    }

}
