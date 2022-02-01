using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtimer : MonoBehaviour
{
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        if (startTime <= 0)
        {
            startTime = 10;
        }

    }

    
     
  
}
