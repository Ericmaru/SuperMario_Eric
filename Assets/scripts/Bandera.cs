using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandera : MonoBehaviour
{
    
 private AudioSource _audioSource;
 public AudioClip FlagSFX;
 private SoundManager _soundManager;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _soundManager = GameObject.Find("BGM Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Flag();
        }
    }

    public void Flag()
    {
        _soundManager.StopMusic();
        _audioSource.PlayOneShot(FlagSFX);
    }


}

