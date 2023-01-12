using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTouch : MonoBehaviour {

    public float Damage = 25f;
    private GameManager gameManager;
    //private ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
        //particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // if hits player, do damage and destroy the bomb
        {
            SoundManagerScript.PlaySound("explosion_classic");
            gameManager.PlayerHealth -= this.Damage;
            if (gameManager.PlayerHealth > 0)
                {
                    SoundManagerScript.PlaySound("pain50_1");
                }
            //particleSystem.Play();
            Destroy(gameObject);
            
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
