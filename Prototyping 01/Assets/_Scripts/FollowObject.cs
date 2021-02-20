using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    
    [Header("OffSet")]
    public Vector3 offset;


    void Update()
    {
        transform.position = objectToFollow.transform.position+offset;
    }
}
