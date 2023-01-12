using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    GameObject Player;

   
	// Use this for initialization
	void Start () {
        Player = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // checks if player is touching the ground with feet

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "MovingGround" /*|| collision.collider.tag == "Ghost"*/)
        {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "MovingGround" /*|| collision.collider.tag == "Ghost"*/)
        {
            Player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("FallingSound"))
        {
            SoundManagerScript.PlaySound("falling1");
        }

    }
}
