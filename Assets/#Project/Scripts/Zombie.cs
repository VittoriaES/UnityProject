using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().zombie = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().zombie = null;
        }
    }

    public void DestroyTrigger()
    {
        Debug.Log("I am dying lalala");
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject);      
    }
}
