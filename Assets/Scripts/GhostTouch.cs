using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTouch : MonoBehaviour {

    public float Damage = 10f;
    private GameManager gameManager;
    private float damageCooldown = 1f;
    private float timer;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // if player hits, do damage, and start cooldown clock
        {
            if (timer >= damageCooldown)
            {
                gameManager.PlayerHealth -= this.Damage;

                if (gameManager.PlayerHealth > 0)
                {
                    SoundManagerScript.PlaySound("pain50_1");
                }
                timer = 0f;
            }
            
            
        }

        if (collision.gameObject.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "FallingPoint")
        {
            Destroy(gameObject);
        }
    }
}
