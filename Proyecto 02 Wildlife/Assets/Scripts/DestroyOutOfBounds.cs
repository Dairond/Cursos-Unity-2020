using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 32f;
    private float bottomBound = -14f;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.z < bottomBound)
        {
            Debug.Log("GAME OVER!!");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        
    }
}
