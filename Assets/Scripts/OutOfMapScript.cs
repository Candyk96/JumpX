using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // play sound if player falls out of map
        {
            SoundManagerScript.PlaySound("falling1");
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
