using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabes;
    public float tileLegnth,distance,numberOfTiles;

    public Transform playerTransform;

    private List<GameObject> active=new List<GameObject>();
    private List<GameObject> obstcales=new List<GameObject>();
    void Start()
    {
        build(0,1,Random.Range(0,3));
        distance+=tileLegnth;
        // for (int i = 0;i<numberOfTiles; i++){
        //     build(Random.Range(1,tilePrefabes.Length),Random.Range(i*(int)(tileLegnth/numberOfTiles)+2,(i+1)*(int)(tileLegnth/numberOfTiles)),Random.Range(0,3));
        // }
    
    }

    // Update is called once per frame
    void Update()
    {
        if(active.Count==10){
            for (int i = 0; i < 4; i++)
            {
                deleteTile();
            }
        }
        if(obstcales.Count>40){
            for (int i = 0; i < 20; i++)
            {
            Destroy(obstcales[0]);
            obstcales.RemoveAt(0);
            }
        }        
        if(playerTransform.position.z>distance-3*tileLegnth){
            for (int i = 0; i < numberOfTiles; i++)
            {
                int times=Random.Range(0,4);
            int zPos=Random.Range(i*(int)(tileLegnth/numberOfTiles),(i+1)*(int)(tileLegnth/numberOfTiles));
            List<int> xPos=new List<int>();

            for (int j = 0; j < times; j++)
            {
                int guess=Random.Range(0,3);
                if (!xPos.Contains(guess)){
                    build(Random.Range(1,tilePrefabes.Length),zPos,guess);
                    xPos.Add(guess);   
                }    
            }
            }


            distance+=tileLegnth;
            build(0,Random.Range(0,(int)tileLegnth),Random.Range(0,3));
        }
    }

    private void build(int idx,int z,int x){
        GameObject at;
        if(idx==0){
            at=Instantiate(tilePrefabes[0],transform.forward*distance,transform.rotation);
            active.Add(at);
        }
        if(idx!=0){
            Vector3 xShift=Vector3.right*(2.5F);
            if (x==0)
                xShift=Vector3.right*(-2.5F);
            if (x==1)
                xShift=Vector3.right*(0);
            xShift.y=0.7F;
            GameObject ac;
            if(idx==3){
                ac=Instantiate(tilePrefabes[idx],transform.forward*(distance+z)+xShift,Quaternion.Euler(-90, 0, 0));
            }
            else
                ac=Instantiate(tilePrefabes[idx],transform.forward*(distance+z)+xShift,transform.rotation);
            obstcales.Add(ac);
        }
    }

    private void deleteTile(){
        Destroy(active[0]);
        active.RemoveAt(0);
    }
}
