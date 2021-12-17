using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Animator dogAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().dog = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().dog = null;
        }
    }

    public void Pet(){
        dogAnimator.SetTrigger("Cuddles");
        Debug.Log("I am being petted");
    }
}
