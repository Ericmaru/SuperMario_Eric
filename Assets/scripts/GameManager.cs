using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool _isPaused = false;
    private SoundManager _soundManager;

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetButtonDown("pause"))
        {
            if(_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
                _soundManager.PauseBGM();
            }
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
                _soundManager.PauseBGM();
            }
        }
    }
}
