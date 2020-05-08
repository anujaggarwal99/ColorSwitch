using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorgenerator : MonoBehaviour
{
     public int ChangerToSpawn = 10;
    public int ChangerDistance = 8;
    public GameObject ColorChanger;
    public Transform changer;
    public float distance=15;
    public Transform cameraT;
    private List<Transform> ChangerList = new List<Transform>();
    // Start is called before the first frame update
    void Start()
     {
        for (int i=0; i<ChangerToSpawn; i++)
        {
            GameObject circle = Instantiate(ColorChanger) as GameObject;
            Transform circleTransform = circle.transform;
            circleTransform.position += new Vector3(0,i*ChangerDistance,0);
            circleTransform.parent = changer;
            ChangerList.Add(circleTransform);
            

            // circleTransform.transform.position = new Vector3( circleTransform.transform.position.x,circleTransform.transform.position.x + ((i+1)*CircleDistance),  circleTransform.transform.position.z);
            // circleTransform.parent = smallcircle;
            // circle.GetComponent<FollowPlayer>().RingGenerator = this;
        }
    }
    private void Update()
    {
        foreach(var circle in ChangerList )
        {
        
            if(circle.position.y < cameraT.position.y)
            {
            
                if (cameraT.position.y - circle.position.y >= distance)
                {
                
                    circle.position = new Vector3(0,circle.position.y + ChangerToSpawn * ChangerDistance, circle.position.z);
                    circle.gameObject.SetActive(true);
                }
            }
        }
    }     

    public Vector2 GetNextPosition()
    {
        return new Vector2(0,ChangerToSpawn * ChangerDistance);
    }
}
