using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroText : MonoBehaviour
{

    public TextMeshProUGUI textDisplayed;
    public Image imageDisplayed;
    public string[] introSentences;
    public Sprite[] introImages;
    public int index;
    public int imageIndex;
    public float typingSpeed;

    public GameObject nextButton;
    public GameObject beginGame;

    private void Start() {
        StartCoroutine(TypeEffect());
    }

    private void Update() {
        if(textDisplayed.text == introSentences[index]){
            nextButton.SetActive(true);
        }
    }

    IEnumerator TypeEffect()
    {
        imageDisplayed.sprite = introImages[imageIndex];
        foreach (char letter in introSentences[index].ToCharArray()){
            textDisplayed.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {
        nextButton.SetActive(false);

        if(index < introSentences.Length - 1 && imageIndex < introImages.Length - 1)
        {
            index ++;
            imageIndex ++;
            textDisplayed.text = "";
            StartCoroutine(TypeEffect());
        }        
        else
        {
            textDisplayed.text = "";
            nextButton.SetActive(false);
            beginGame.SetActive(true);
        }
    }


}

