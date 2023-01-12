using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public bool isGrounded = false;
    private bool left, right;

    // Use this for initialization
    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (movement.x < 0)
        {
            TurnLeft();
        }
        if (movement.x > 0)
        {
            TurnRight();
        }

    }

    void TurnLeft()
    {
        if (left)
            return;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        left = true;
        right = false;
    }

    void TurnRight()
    {
        if (right)
            return;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        left = false;
        right = true;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            SoundManagerScript.PlaySound("jump1");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "JumpPad")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed * 2), ForceMode2D.Impulse);
            SoundManagerScript.PlaySound("jump1");
        }
        
    }

}
