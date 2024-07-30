using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BoboController : MonoBehaviour
{
    Rigidbody2D boboRB;
    Animator playerAnimator;
    
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;
    
    bool facingRight = true;


    void Start()
    {
        boboRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();


        if (boboRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (boboRB.velocity.x < 0 && !facingRight)
        {
            FlipFace();
        } 

        if (Input.GetAxis("Vertical") > 0)
        {
            jump();
        }
    }

    void HorizontalMove() //Yatay Hareket
    {
        boboRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, boboRB.velocity.y);
        playerAnimator.SetFloat("speed" , Mathf.Abs(boboRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void jump()
    {
        boboRB.AddForce(new Vector2(0f , jumpSpeed));
    }
}
