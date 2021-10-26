using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;

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
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interacting");
        if(door != null){
            door.DoorChangeScene();      
        }
    }
}

// TODO Pick up objects
// * when you pick up an object overimpose a canvas that will show:
// * 1. name
// * 2. small description
// * 3. object zoomed in to show it better

// * give the player the time to read
// * only hide the canvas once the player presses another button

// TODO Get closer to view areas
// * Press a button to examine an area, overimpose a new canvas that shows:
// * Zoomed in area with the various objects lying around
// * Make objects interactable(UP-DOWN arrows to choose objects)
// * Find a way to highlight the object (make it slightly bigger?)


