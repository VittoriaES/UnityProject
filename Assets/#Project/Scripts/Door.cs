using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().door = this;
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().door = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorChangeScene(){
        Debug.Log("ACTION DOOR ");
        SceneManager.LoadScene(destination);
    }
}


