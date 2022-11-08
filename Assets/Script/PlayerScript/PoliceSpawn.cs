using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawn : MonoBehaviour
{
    public GameObject car;
    public float maxPos = 2.2f;
    public float delayTime = 1f;
    float time;
    
    private void Start()
    {
        time = delayTime;
        
    }
    private void Update()
    {
        time-=Time.deltaTime;
        if(time < 0)
        {
            Vector3 poss = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            Quaternion policeRotation = transform.rotation;
            policeRotation.z = 180;
            Instantiate(car, poss, policeRotation);
            time=delayTime;
        }
        
        //Debug.Log(car.transform.position.y);

    }
   
}
