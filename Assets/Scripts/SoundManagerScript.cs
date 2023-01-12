using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip coinPickupSound, s_HealthSound, n_HealthSound, l_HealthSound, m_HealthSound, explosionSound, fallingSound, lostSound, jumpSound, painSound, winSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        coinPickupSound = Resources.Load<AudioClip>("bell_01");
        s_HealthSound = Resources.Load<AudioClip>("s_health");
        n_HealthSound = Resources.Load<AudioClip>("n_health");
        l_HealthSound = Resources.Load<AudioClip>("l_health");
        m_HealthSound = Resources.Load<AudioClip>("m_health");
        explosionSound = Resources.Load<AudioClip>("explosion_classic");
        fallingSound = Resources.Load<AudioClip>("falling1");
        lostSound = Resources.Load<AudioClip>("you_lose");
        jumpSound = Resources.Load<AudioClip>("jump1");
        painSound = Resources.Load<AudioClip>("pain50_1");
        winSound = Resources.Load<AudioClip>("you_win");
        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "bell_01":
                audioSrc.PlayOneShot(coinPickupSound);
                break;
            case "s_health":
                audioSrc.PlayOneShot(s_HealthSound);
                break;
            case "n_health":
                audioSrc.PlayOneShot(n_HealthSound);
                break;
            case "l_health":
                audioSrc.PlayOneShot(l_HealthSound);
                break;
            case "m_health":
                audioSrc.PlayOneShot(m_HealthSound);
                break;
            case "explosion_classic":
                audioSrc.PlayOneShot(explosionSound);
                break;
            case "falling1":
                audioSrc.PlayOneShot(fallingSound);
                break;
            case "you_lose":
                audioSrc.PlayOneShot(lostSound);
                break;
            case "jump1":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "pain50_1":
                audioSrc.PlayOneShot(painSound);
                break;
            case "you_win":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}
