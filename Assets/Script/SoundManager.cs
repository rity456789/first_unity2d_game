using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound, swordSound, crashSound;
 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("Coin");
        swordSound = Resources.Load<AudioClip>("Sword");
        crashSound = Resources.Load<AudioClip>("Crash");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCoinSound()
    {
        audioSource.clip = coinSound;
        audioSource.PlayOneShot(coinSound, 1f);
    }

    public void PlaySwordSound()
    {
        audioSource.clip = swordSound;
        audioSource.PlayOneShot(swordSound, 0.7f);
    }

    public void PlayCrashSound()
    {
        audioSource.clip = crashSound;
        audioSource.PlayOneShot(crashSound, 1f);
    }
}
