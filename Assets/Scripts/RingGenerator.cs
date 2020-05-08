using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour
{


    public int CircleToSpawn = 10;
    public int CircleDistance = 8;
    public GameObject SmallCircle;
    public Transform circles;
    public float distance=15;
    public Transform cameraT;
    private List<Transform> CirclesList = new List<Transform>();
    // public float MinY;
    // public float MaxY;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<CircleToSpawn; i++)
        {
            GameObject circle = Instantiate(SmallCircle) as GameObject;
            Transform circleTransform = circle.transform;
            circleTransform.position += new Vector3(0,i*CircleDistance,0);
            circleTransform.parent = circles;
            CirclesList.Add(circleTransform);
        }
    }
    private void Update()
    {
        foreach(var circle in CirclesList )
        {
        
            if(circle.position.y < cameraT.position.y)
            {
            
                if (cameraT.position.y - circle.position.y >= distance)
                {
                
                    circle.position = new Vector3(0,circle.position.y + CircleToSpawn * CircleDistance, circle.position.z);
                }
            }
        }
    }      
    public Vector2 GetNextPosition()
    {
        return new Vector2(0,CircleToSpawn * CircleDistance);
    }
}
