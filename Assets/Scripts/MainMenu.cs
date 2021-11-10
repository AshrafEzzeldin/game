using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    // public void Resume(){
    //     PausePanel.SetActive(false);
    //     Time.timeScale=1;
    // }

    void Start()
    {
        FindObjectOfType<AudioManger>().PlaySound("midwin");

    }
        
    
    public void Play(){
        // FindObjectOfType<AudioManger>().StopSound("game");
        // FindObjectOfType<AudioManger>().PlaySound("game");
        SceneManager.LoadScene("Level");
    }

    public void Quit(){
        Application.Quit();
    }
}



