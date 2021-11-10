using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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

    public ItemViewController itemViewController;

    

    public Door door = null;

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
        if(door != null){
            door.DoorChangeScene();      
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
            Destroy(itemTBP);

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
        var item = other.GetComponent<Item>();
        if (item)
        {
            Debug.Log("Item can be picked up");
            pickableObject = false;
            itemTBP = item;
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


