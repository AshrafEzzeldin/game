using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public Vector3 offset,mainPos;

    private bool cam;
    // Start is called before the first frame update
    void Start()
    {
        mainPos=transform.position;
        cam=true;
        offset=target.position-transform.position;    
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if((Input.GetKeyDown("c"))&&Time.timeScale==1){
            cam=!cam;
        }
        if(cam){
        Vector3 newPosition=mainPos;
        newPosition.z=target.position.z-offset.z;
        transform.position=Vector3.Lerp(transform.position,newPosition,10*Time.deltaTime);
        }
        else{
            transform.position=Vector3.Lerp(transform.position,target.position+new Vector3(0,2,0),10*Time.deltaTime);
        }
    }

    public void switchs(){
        cam=!cam;
    }
}
