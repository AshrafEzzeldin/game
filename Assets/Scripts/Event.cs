using UnityEngine.SceneManagement;
using UnityEngine;


public class Event : MonoBehaviour
{
    // public Text mute;
    public GameObject PausePanel,HowPanel,creditsPanel;
    public GameObject MainMenuPanel;   
    // public Button mute; 
    public void Restart(){
        SceneManager.LoadScene("Level");
    }

    public void Resume(){
        PausePanel.SetActive(false);
        FindObjectOfType<AudioManger>().StopSound("all");
        FindObjectOfType<AudioManger>().PlaySound("game");

        Time.timeScale=1;
    }

    
    public void How(){
        FindObjectOfType<AudioManger>().PlaySound("midwin");    
        HowPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void credits(){
        FindObjectOfType<AudioManger>().PlaySound("midwin");
        creditsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Mute(){

        PlayerManager.mute=!PlayerManager.mute;
        if(PlayerManager.mute)
            FindObjectOfType<AudioManger>().StopSound("midwin");
        else
            FindObjectOfType<AudioManger>().PlaySound("midwin");

        // if(PlayerManager.mute){
        //     // mute.text = "Unmute";
        // }
        // else{
        //     mute.text = "Mute";
        // }
    }
    public void Play(){
        SceneManager.LoadScene("Level");
        // MainMenuPanel.SetActive=false;
    }

    public void Quit(){
        Application.Quit();
        // MainMenuPanel.SetActive=false;
    }

}
