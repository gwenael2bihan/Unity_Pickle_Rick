using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame () {
        FindObjectOfType<AudioManager>().Stop("InMenu");
        FindObjectOfType<AudioManager>().Play("PlayButton");
        FindObjectOfType<AudioManager>().Play("InGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   }

    public void ButtonSound() {
        FindObjectOfType<AudioManager>().Play("Button");
    }

   public void QuitGame () {
       Debug.Log("QUIT!!");
       Application.Quit();
   }
}
