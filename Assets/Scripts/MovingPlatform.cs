using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public bool isStopped = true;
    public bool reachedEnd = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStopped == false && reachedEnd == false)  // move the platform if it hasn't reached end point
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0f, 0f);
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * 0f, 0f, 0f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)  // make the player move with the platform
    {
        if ((collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") && reachedEnd == false)
        {
            isStopped = false;
            collision.transform.parent = this.transform;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision) // stop player from moving with platform
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            collision.transform.parent = null;
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("MovingGroundStop"))
        {
            isStopped = true;
            reachedEnd = true;
        }
    }
}
