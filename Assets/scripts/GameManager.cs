using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool _isPaused = false;
    private SoundManager _soundManager;
    public GameObject pauseCanvas;
    private int coins = 0;
    public Text coinsText;

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
       coinsText.text = "coins: " + coins.ToString();
    }

    void Update()
    {
        if(Input.GetButtonDown("pause"))
        Pause();
    }
    // Update is called once per frame
    public void Pause()
    {  
        if(Input.GetButtonDown("pause"))
        {
            if(_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(true);
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void AddCoins()
    {
        coins++;
        coinsText.text = "coins: " + coins.ToString();
    }

}
