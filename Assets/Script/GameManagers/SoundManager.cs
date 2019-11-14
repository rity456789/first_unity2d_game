using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound, swordSound, crashSound, jumpSound, hurtSound, heartSound, fullHeartSound, shoeSound, shoeOutSound, knockDoorSound, victorySound;
 
    private AudioSource effectAudioSource;
    private AudioSource BGAudioSource;

    private float effectVolume;
    // Start is called before the first frame update
    void Start()
    {
        // coinSound = Resources.Load<AudioClip>("Coin");
        // swordSound = Resources.Load<AudioClip>("Sword");
        // crashSound = Resources.Load<AudioClip>("Crash");
        // jumpSound = Resources.Load<AudioClip>("Jump");
        // hurtSound = Resources.Load<AudioClip>("Hurt");
        // heartSound = Resources.Load<AudioClip>("Heart");
        // fullHeartSound = Resources.Load<AudioClip>("FullHeart");
        // shoeSound = Resources.Load<AudioClip>("Shoe");
        // shoeOutSound = Resources.Load<AudioClip>("ShoeOut");


        effectAudioSource = GetComponent<AudioSource>();
        BGAudioSource = GameObject.FindGameObjectWithTag("BackGroundSound").GetComponent<AudioSource>();

        Scene activeScreen = SceneManager.GetActiveScene();
        if (activeScreen.buildIndex == 1) BGAudioSource.volume = PlayerPrefs.GetFloat("bgVolume", 0.5f);
        else BGAudioSource.volume = PlayerPrefs.GetFloat("bgVolume", 0.5f)/5;

        effectVolume = PlayerPrefs.GetFloat("effectVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // basic function
    public void PlaySound(AudioClip sound, float volumn)
    {
        float playVolumn = volumn * effectVolume * 0.7f;
        effectAudioSource.clip = sound;
        effectAudioSource.PlayOneShot(sound, playVolumn);
    }

    // -------------------------------------------------------------------------------
    public void PlayCoinSound()
    {
        PlaySound(coinSound, 1f);
    }

    public void PlaySwordSound()
    {
        PlaySound(swordSound, 0.5f);
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

    public void PlayShoeOutSound()
    {
        PlaySound(shoeOutSound, 0.7f);
    }

    public void PlayKnockDoorSound()
    {
        PlaySound(knockDoorSound, 0.7f);
    }

    public void PlayVictorySound()
    {
        PlaySound(victorySound, 1f);
    }
}
