using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
public float speed; 
private float moveInput;
private bool  facingRight = true; 
private Rigidbody2D rb; 
public VectorValue startingPosition; 




void Start(){
    rb = GetComponent<Rigidbody2D>();

    /// Setting the Starting position through VectorValue
    transform.position = startingPosition.initialValue;
}

void FixedUpdate(){
    moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    if(facingRight == false && moveInput > 0){
        Flip();
    } else if(facingRight == true&& moveInput < 0){
        Flip(); 
    }
}

void Flip(){
    facingRight = !facingRight;

     // Old Code ->
   Vector3 Scaler = transform.localScale;
   Scaler.x *= -1;
   transform.localScale = Scaler; 
}

}



