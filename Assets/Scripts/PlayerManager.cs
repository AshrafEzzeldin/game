using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public static bool gameOver,shield;
    public static int score,coins,blue;
    public GameObject GameOverPanel,PausePanel;
    public static float timeSpeed,shieldTime;
    public Text cointext,scoreText,blueText;

    public static bool mute=false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1; 
        gameOver=false;
        score=0;
        coins=0;
        blue=0;
        timeSpeed=0;
        shieldTime=0;
        shield=false;
    }

    // Update is called once per frame
    void Update()
    {



        // if(score<0){
        //     gameOver=true;
        // }

        cointext.text="Coins: "+coins;
        scoreText.text="Score: "+score;
        blueText.text="Blue: "+blue;
        if(Input.GetKeyDown("escape")){
            d();
        }
        if(gameOver){
            Time.timeScale=0; 
            GameOverPanel.SetActive(true);
        }
    }

    public void d(){
                    PausePanel.SetActive(true);   
            FindObjectOfType<AudioManger>().StopSound("all");
            FindObjectOfType<AudioManger>().PlaySound("midwin");
            
            Time.timeScale=0; 

    }
}
