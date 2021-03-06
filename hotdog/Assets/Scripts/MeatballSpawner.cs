using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballSpawner : MonoBehaviour
{
    [SerializeField] Transform originPoint;
    [SerializeField] GameObject meatball;

    private float timer;
    private float randNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       
       if (PauseMenu.GameIsPaused)
       {
           return;
       }
        
        timer += Time.deltaTime;
        randNum = Random.Range(0f, 480f);
        if (timer >= randNum)
        {
            for(int i=0; i < 4; i++)
            {
                Vector3 randCoords = new Vector3(Random.Range(-25f, 25f), 0, Random.Range(-25f, 25f));
                Instantiate(meatball, randCoords + originPoint.transform.position, Quaternion.identity);
            }
            timer = 0;
            //randNum = Random.Range(0f, 30f);

        }
    }
}
