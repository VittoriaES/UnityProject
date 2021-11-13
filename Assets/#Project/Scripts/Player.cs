using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Rigidbody2D rb;
    public CanvasBehaviour canvas;

    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;

    public InventoryObject inventory;
    public Item itemTBP;

    private bool pickableObject = true;
    private bool isCanvasActive = false;
    private bool isNotReading = true;

    private bool canOpenDoor = false;

    public ItemViewController itemViewController;

    public Door door = null;

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
        if(isNotReading)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interacting");
        if (door != null &&  canOpenDoor)
        {
            door.DoorChangeScene();
            itemViewController.UpdateDisplay();
        }
        if (door != null &&  !canOpenDoor)
        {
            Debug.Log("You cannot open the door!");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            Debug.Log("Item can be picked up");
            pickableObject = false;
            itemTBP = item;
        }

        Door door = other.GetComponent<Door>();
        if (door)
        {
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
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Object"))
        {
            Debug.Log("Cannot be picked up anymore");
            pickableObject = true;
        }
    }
}


