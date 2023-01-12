using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrapStep : MonoBehaviour
{
    private float trapDestroyWaitTime = 0.5f;
    private float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) // if player hits, destroy the platform with small delay
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            if (timer >= trapDestroyWaitTime)
            {
                Destroy(gameObject);
                timer = 0f;
            }
        }
    }
}
