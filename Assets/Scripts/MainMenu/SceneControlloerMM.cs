using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlloerMM : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        Application.LoadLevel("CharacterSelect");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
