using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    private Vector3 direction;

    public int forwardSpeed;

    public float shift;

    public int lane;

    public float jumpForce;

    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();

        direction.z=forwardSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerManager.shieldTime>0){
            PlayerManager.shieldTime-=Time.deltaTime;
        }
        else{
            PlayerManager.shield=false;
            if(PlayerManager.shieldTime!=0){
                FindObjectOfType<AudioManger>().StopSound("inv");
                FindObjectOfType<AudioManger>().PlaySound("game");
            }
            PlayerManager.shieldTime=0;
        }
        if(PlayerManager.blue%3==0&&PlayerManager.blue!=0&&direction.z==forwardSpeed){
            direction.z*=2;
        }
        if(PlayerManager.timeSpeed>0){
            PlayerManager.timeSpeed-=Time.deltaTime;
        }
        else{
            direction.z=forwardSpeed;
            if(PlayerManager.timeSpeed!=0){
                FindObjectOfType<AudioManger>().StopSound("speed");
                FindObjectOfType<AudioManger>().PlaySound("game");
            }

            PlayerManager.timeSpeed=0;
        }
        if(controller.isGrounded){       
            if((Input.GetKeyDown("space")||SwipeManager.swipeUp)&&Time.timeScale==1){
                direction.y=0;
                jump();
            }
        }
        else{
        direction.y+=gravity*Time.deltaTime; 
        }

        controller.Move(direction* Time.deltaTime);
        
        if((Input.GetKeyDown(KeyCode.LeftArrow)||SwipeManager.swipeLeft)&&Time.timeScale==1){
            lane--;
            if(lane==-1)
                lane=0;    
        }

        if((Input.GetKeyDown(KeyCode.RightArrow)||SwipeManager.swipeRight)&&Time.timeScale==1){
            lane++;
            if(lane==3)
                lane=2;    
        }
        
        Vector3 newPosition= transform.position.z*transform.forward+ transform.position.y*transform.up;

        if(lane==0)
            newPosition+=Vector3.left*shift;

        if(lane==2)
            newPosition+=Vector3.right*shift;


        // newPosition+=transform.forward*direction.z;
        transform.position=Vector3.Lerp(transform.position,newPosition,80*Time.deltaTime);
    }

    public void jump(){
        if(controller.isGrounded)
            direction.y=jumpForce;
    }


    // void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     if(hit.transform.tag=="Blue"){
    //         PalyerManager.gameOver=true;
    //     }
    // }
}
