using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextSelectorBM : MonoBehaviour
{
    public SceneControllerBM controller;
    public int playernum;
    public Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playernum == 1)
        {
            buttonText.text = controller.GetPlayer1Key();
        }
        else
        {
            buttonText.text = controller.GetPlayer2Key();
        }
    }
}
