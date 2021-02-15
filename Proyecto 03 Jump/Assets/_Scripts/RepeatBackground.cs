using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWeight;
    
    void Start()
    {

        startPos = transform.position;
        repeatWeight = GetComponent<BoxCollider>().size.x / 2;
    }

    
    void Update()
    {
        if (startPos.x - transform.position.x > repeatWeight)
        {
            transform.position = startPos;
        }
    }
}
