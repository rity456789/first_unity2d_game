using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound, swordSound, crashSound, jumpSound, hurtSound, heartSound, fullHeartSound, shoeSound;
 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("Coin");
        swordSound = Resources.Load<AudioClip>("Sword");
        crashSound = Resources.Load<AudioClip>("Crash");
        jumpSound = Resources.Load<AudioClip>("Jump");
        hurtSound = Resources.Load<AudioClip>("Hurt");
        heartSound = Resources.Load<AudioClip>("Heart");
        fullHeartSound = Resources.Load<AudioClip>("FullHeart");
        shoeSound = Resources.Load<AudioClip>("Shoe");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // basic function
    public void PlaySound(AudioClip sound, float volumn)
    {
        audioSource.clip = sound;
        audioSource.PlayOneShot(sound, volumn);
    }

    // -------------------------------------------------------------------------------
    public void PlayCoinSound()
    {
        PlaySound(coinSound, 1f);
    }

    public void PlaySwordSound()
    {
        PlaySound(swordSound, 0.7f);
    }

    public void PlayCrashSound()
    {
        PlaySound(crashSound, 0.7f);
    }

    public void PlayJumpSound()
    {
        PlaySound(jumpSound, 0.7f);
    }

    // ---------------------------------------------------------------------------------
    public void PlayHurtSound()
    {
        PlaySound(hurtSound, 1f);
    }

    public void PlayHeartSound()
    {
        PlaySound(heartSound, 0.7f);
    }

    public void PlayFullHeartSound()
    {
        PlaySound(fullHeartSound, 0.7f);
    }

    public void PlayShoeSound()
    {
        PlaySound(shoeSound, 0.7f);
    }
}
