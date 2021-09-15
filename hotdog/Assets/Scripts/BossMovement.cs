using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform cube;
    public float RPM;
    private float timeKeep;
    

    void Start()
    {
        timeKeep = 10f;

    }

    void Update()
    {   

        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        //Debug.Log(Time.realtimeSinceStartupAsDouble);
        float currentTime = Time.realtimeSinceStartup;

        if (currentTime > timeKeep)
        {
            cube.transform.Rotate(0,RPM * Time.fixedDeltaTime * -1, 0);
            float randNum = Random.Range(10f, 30f);

            if(currentTime > (timeKeep + randNum) )
            {
                timeKeep += (randNum*2);
            }
            

        }
        else
        {
            cube.transform.Rotate(0,RPM * Time.fixedDeltaTime, 0);
        }
        
    }
    
}