using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{

    // Start is called before the first frame update
    public Sounds[]sounds;
    void Start()
    {
        foreach(Sounds s in sounds){
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.source.loop=s.loop;
        }

        PlaySound("game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string name){
        // print(PlayerManager.mute);
        if(PlayerManager.mute)
            return;
        foreach(Sounds s in sounds){
            if(s.name==name){
                s.source.Play();
            }
        }
        if(name=="gameOver"||name=="inv"||name=="speed"||name=="midwin"){
            foreach(Sounds s in sounds){
            if(s.name!=name){
                s.source.Stop();
            }
        }   
        }
    }
    public void StopSound(string name){
        foreach(Sounds s in sounds){
            // if(s.name==name){
                s.source.Stop();
            // }
        }
        if(name=="inv"||name=="speed")
            FindObjectOfType<AudioManger>().PlaySound("game");
    }

}
