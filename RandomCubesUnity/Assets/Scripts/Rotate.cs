using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
           //give a slight random rotation
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 540f);
        transform.eulerAngles = euler;
        euler.x = Random.Range(0f, 540f);
        transform.eulerAngles = euler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    }