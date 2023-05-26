using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float maxSpeed = 6.0f;
    public float moveDirection;
    public bool facingRight = true;
    private Animator anim;
    private Rigidbody rgbdy;

    // Start is called before the first frame update
    void Start()
    {
        rgbdy = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


    }
    void FixedUpdate()
    {
        rgbdy.velocity = new Vector2(moveDirection * maxSpeed, rgbdy.velocity.y);

        if (moveDirection > 0.0f && !facingRight)
        {
            Flip();
        } else if (moveDirection < 0.0f && !facingRight)
        {
            Flip();

        }

        anim.SetFloat("Speed", Mathf.Abs(moveDirection));
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }
}