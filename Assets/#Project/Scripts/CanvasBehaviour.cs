using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject canvasItem;

    public void showCanvas()
    {
        canvasItem.SetActive(true);
        Debug.Log("Canvas is active");
    }
    
    public void hideCanvas()
    {
        canvasItem.SetActive(false);
    }
}
