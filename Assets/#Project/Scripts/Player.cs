using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rigidbody2D;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D> ();
    }

    void FixedUpdate() {
        if (Input.GetKey (KeyCode.LeftArrow)) {
            rigidbody2D.velocity = new Vector2 (speed * -1, rigidbody2D.velocity.y);
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2 ( speed, rigidbody2D.velocity.y);
        }
    }
}
