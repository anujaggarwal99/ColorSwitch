using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int StarToSpawn = 10;
    public int StarDistance = 5;
    public GameObject smallstar;
    public Transform stars;
    public float distance=15;
    public Transform cameraT;
    private List<Transform> StarList = new List<Transform>();
    // public float MinY;
    // public float MaxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<StarToSpawn; i++)
        {
            GameObject star = Instantiate(smallstar) as GameObject;
            Transform starTransform = star.transform;
            starTransform.position += new Vector3(0,i*StarDistance,0);
            starTransform.parent = stars;
            StarList.Add(starTransform);
            //circle.GetComponent<FollowPlayer>().RingGenerator = this;
            // circleTransform.transform.position = new Vector3( circleTransform.transform.position.x,circleTransform.transform.position.x + ((i+1)*CircleDistance),  circleTransform.transform.position.z);
            // circleTransform.parent = smallcircle;
            
        }
    }

      private void Update()
    {
        foreach(var star in StarList )
        {
        
            if(star.position.y < cameraT.position.y)
            {
            
                if (cameraT.position.y - star.position.y >= distance)
                {
                
                    star.position = new Vector3(0,star.position.y + StarToSpawn * StarDistance, star.position.z);
                    star.gameObject.SetActive(true);
                }
            }
        }
    }     
    

    public Vector2 GetNextPosition()
    {
        return new Vector2(0,StarToSpawn * StarDistance);
    }
}
