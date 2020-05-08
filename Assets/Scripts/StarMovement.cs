using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public StarGenerator StarGenerator;
    public int StarToSpawn = 10;
    public int StarDistance = 8;
    public float distance=15;
    public Transform cameraT;
    public Transform star;
    private List<Transform> StarList = new List<Transform>();
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        foreach(var star in StarList )
        {
        
            if(star.position.y < cameraT.position.y)
            {
            
                if (cameraT.position.y - star.position.y >= distance)
                {
                
                    star.position = new Vector3(0,star.position.y + StarToSpawn * StarDistance, star.position.z);
                }
            }
        }
        
    }
    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("star"))
    //     {
    //         ScoreManager.score += 1;
    //         Debug.Log(ScoreManager.score);
         
    //     }
    // }

}
