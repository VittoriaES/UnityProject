using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Rigidbody2D rb;
    public CanvasBehaviour canvasMenu;
    public CanvasBehaviour canvas;
    public CanvasBehaviour canvasTip;
    public CanvasBehaviour canvasQTE;
    public CanvasBehaviour canvasFinalChoice;
    public SceneChanger sceneChanger;

    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;

    public InventoryObject inventory;
    public Item itemTBP;

    private bool pickableObject = true;
    private bool isCanvasActive = false;
    private bool isNotReading = true;

    private bool canOpenDoor = false;
    private bool canPetDog = false;
    private bool canMakeFinalChoice = false;
    private bool menuOpened = false;

    public ItemViewController itemViewController;

    public Door door = null;
    public Dog dog = null;
    public Zombie zombie = null;
    public Porch porch = null;

    private void Awake() {
        if(instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isNotReading)
        {
            horizontal = 0f;
        }

        if (!isFacingRight && horizontal > 0f) 
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

    }

    private void Flip()
    {
        if (isNotReading)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interacting");
        if (door != null &&  canOpenDoor)
        {
            door.DoorChangeScene();
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.itemName == "FrontDoorKey")
                {
                    inventory.Container.RemoveAt(i);
                }
            }
            itemViewController.UpdateDisplay();
        }

        if (door != null &&  !canOpenDoor)
        {
            Debug.Log("You cannot open the door!");
        }

        if (canPetDog == true)
        {
            Debug.Log("I am petting the dog");
            dog.Pet();
        }

        if (porch != null && canMakeFinalChoice)
        {
            Debug.Log("Can make final choice");
            canvasFinalChoice.showFinalChoice();
            isNotReading = false;
        }

    }

    public void PickUp(InputAction.CallbackContext context)
    {
        Debug.Log("Picking up!!");

        if(pickableObject == false && itemTBP){
            canvas.showCanvas();
            isNotReading = false;
            isCanvasActive = true;
            Debug.Log("Canvas showing up");
            pickableObject = true;
            inventory.AddItem(itemTBP.item, 1);
            itemViewController.UpdateDisplay();
            Destroy(itemTBP.gameObject);
            Debug.Log("object destroyed");

        }

    }

    public void ExitCanvas(InputAction.CallbackContext context)
    {
        if (isCanvasActive == true)
        {
            Debug.Log("Canvas is removed");
            canvas.hideCanvas();
            isCanvasActive = false;
            isNotReading = true;
        }
    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Menu button pressed");
            if (menuOpened == false)
            {
                canvasMenu.showMenu();
                menuOpened = true;
                Time.timeScale = 0f;
            }
            else 
            {
                canvasMenu.hideMenu();
                menuOpened = false;
                Time.timeScale = 1f;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            canvasTip.showTipPickUp();
            Debug.Log("Item can be picked up");
            pickableObject = false;
            itemTBP = item;
            Debug.Log("the item can be added");
        }

        Door door = other.GetComponent<Door>();
        if (door)
        {   
            canvasTip.showTipInteract();

            for (int i = 0; i < inventory.Container.Count; i++)
            {   
                if (inventory.Container[i].item.itemName == "FrontDoorKey")
                {
                    canOpenDoor = true;
                    Debug.Log("Door can be opened!!");
                    break;
                }
            }
        }

        Dog dog = other.GetComponent<Dog>();
        if (dog)
        {
            canvasTip.showTipInteract();
            Debug.Log("Can pet Dog");
            canPetDog = true;
        } 

        Zombie zombie = other.GetComponent<Zombie>();
        if (zombie)
        {   
            Debug.Log("Near zombie");
            canvasQTE.startQTE();
            isNotReading = false;
        }

        Porch porch = other.GetComponent<Porch>();
        if (porch)
        {
            Debug.Log("Near porch");
            canMakeFinalChoice = true;           
        }     
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Object"))
        {   
            canvasTip.hideTipPickUp();
            Debug.Log("Cannot be picked up anymore");
            pickableObject = true;
        }

        if(other.CompareTag("Door"))
        {
            Debug.Log("Cannot interact with door");
            canvasTip.hideTipInteract();
        }

        if(other.CompareTag("Dog"))
        {
            canPetDog = false;
            canvasTip.hideTipInteract();
        }

        if (zombie)
        {   
            canvasQTE.endQTE();
            isNotReading = true;
        }

        if (porch)
        {
            Debug.Log("Away from porch");
            canMakeFinalChoice = false;
        }

    }
}


