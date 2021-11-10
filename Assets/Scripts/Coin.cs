using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,20*Time.deltaTime*10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            FindObjectOfType<AudioManger>().PlaySound("collect");

            PlayerManager.score+=15;
            PlayerManager.coins++;            
            if(PlayerManager.coins%3==0){
                PlayerManager.shield=true;
                if(PlayerManager.shieldTime==0)
                    FindObjectOfType<AudioManger>().PlaySound("inv");
                PlayerManager.shieldTime=5;
            } 
            Destroy(gameObject);
        }
    }
}
