using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Vector3 obstaclePos;
    private float leftLimit= -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstaclePos = transform.position;
        if (obstaclePos.x <= leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
