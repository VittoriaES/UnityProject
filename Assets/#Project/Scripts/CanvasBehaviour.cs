using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject canvasItem;
    public GameObject canvasTip;
    public GameObject canvasQTE;
    public GameObject canvasFinalChoice;
    public GameObject canvasMenu;

    public Player player;

    public TMP_Text textName;
    public TMP_Text textDescription;

    public GameObject textInteract;
    public GameObject textPickUp;

    public Image itemZoom;

    public void showMenu()
    {
        canvasMenu.SetActive(true);
    }
    public void hideMenu()
    {
        canvasMenu.SetActive(false);
    }
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

    public void showTipInteract()
    {
        canvasTip.SetActive(true);
        textInteract.SetActive(true);
    }

    public void hideTipInteract()
    {
        canvasTip.SetActive(false);
        textInteract.SetActive(false);
    }

    public void showTipPickUp()
    {
        canvasTip.SetActive(true);
        textPickUp.SetActive(true);
    }

    public void hideTipPickUp()
    {
        canvasTip.SetActive(false);
        textPickUp.SetActive(false);
    }
    
    public void startQTE()
    {
        canvasQTE.SetActive(true);
    }

    public void endQTE()
    {
        canvasQTE.SetActive(false);
    }

    public void showFinalChoice()
    {
        canvasFinalChoice.SetActive(true);
    }
    public void hideFinalChoice()
    {
        canvasFinalChoice.SetActive(false);
    }
}
