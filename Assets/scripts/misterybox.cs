using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misterybox : MonoBehaviour
{

 public Transform MushroomSpawn;
public GameObject[] MushroomPrefab;
public int MushroomIndex;
    Animator _animator;
    AudioSource _audioSource;
   public  AudioClip _misteryboxSFX;
public AudioClip _misteryBoxSFX2;
bool _isOpen = false;

   void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
   
   void ActivateBox()
   {
        if(!_isOpen)
        {
        _animator.SetTrigger("OpenBox");
        _audioSource.volume = 1f;
         _audioSource.clip = _misteryboxSFX;
            MushroomOut();
            _isOpen = true;
        }
        else
        {
         _audioSource.volume = 0.5f;
         _audioSource.clip = _misteryBoxSFX2;
        }
        _audioSource.Play();
   }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ActivateBox();
        }
    }

    void MushroomOut()
{
    Instantiate(MushroomPrefab[MushroomIndex], MushroomSpawn.position, MushroomSpawn.rotation);
}
}