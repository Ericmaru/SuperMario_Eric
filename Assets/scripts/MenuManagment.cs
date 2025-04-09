using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManagment : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

     public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    
     public void PlayerDead()
    {
        SceneManager.LoadScene(2);
    }


    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }

}