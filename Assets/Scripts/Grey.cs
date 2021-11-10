using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grey : MonoBehaviour
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

            if(!PlayerManager.shield){
                FindObjectOfType<AudioManger>().PlaySound("dead");
                PlayerManager.score-=10;
            }
            if(PlayerManager.score<=0){
                FindObjectOfType<AudioManger>().StopSound("game");
                FindObjectOfType<AudioManger>().PlaySound("gameOver");
                PlayerManager.gameOver=true;
            }
            Destroy(gameObject);
        }
    }

}
