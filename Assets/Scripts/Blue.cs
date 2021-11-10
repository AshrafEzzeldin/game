using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            FindObjectOfType<AudioManger>().PlaySound("collect");

            PlayerManager.score+=10;
            PlayerManager.blue++;            
            if(PlayerManager.blue%3==0){
                if(PlayerManager.timeSpeed==0)
                    FindObjectOfType<AudioManger>().PlaySound("speed");
                PlayerManager.timeSpeed=7;

            }
            Destroy(gameObject);
        }
    }    
}
