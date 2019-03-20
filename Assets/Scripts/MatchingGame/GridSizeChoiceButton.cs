using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSizeChoiceButton : MonoBehaviour
{
    [SerializeField] private int numRows;
    [SerializeField] private int numcols;

    public void OnMouseDown()
    {
        SceneController controller = GameObject.FindObjectOfType<SceneController>();
        controller.gridRows = numRows;
        controller.gridCols = numcols;
        controller.CreateCards();
    }
}
