using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame () {
        FindObjectOfType<AudioManager>().Play("PlayButton");
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
