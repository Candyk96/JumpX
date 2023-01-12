using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour {

    public float moveSpeed = 1f;
    public bool movingRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight == true) // movement to right and left
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0f, 0f);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0f, 0f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn")) // if ghost hits a turning point, it turns back
        {
            if (movingRight == true)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
    }

}
