using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float Counter;
    private float waitTime = 1f;

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Counter += Time.deltaTime;
        // On spacebar press, send dog
        if (Counter >= waitTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                Counter = 0;
            }
        }
    }
}
