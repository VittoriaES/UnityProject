using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject canvasItem;

    public Player player;

    public TMP_Text textName;
    public TMP_Text textDescription;

    public Image itemZoom;


    public void showCanvas()
    {
        canvasItem.SetActive(true);
        Debug.Log("Canvas is active");
        textName.text = player.itemTBP.item.displayName;
        textDescription.text = player.itemTBP.item.description;
        itemZoom.sprite = player.itemTBP.item.zoomedIcon;
    }
    
    public void hideCanvas()
    {
        canvasItem.SetActive(false);
    }
}
