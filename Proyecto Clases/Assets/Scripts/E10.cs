using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E10 : MonoBehaviour
{
    private int[] A = { 1, 2, 3 };
    private int[] B = { 4, 5, 6 };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(((A[0] + A[1] + A[2]) % 2) == 0 ?
            "La suma de los elementos de A es par" : "La suma de los elementos de A es impar");
        Debug.Log(((B[0] + B[1] + B[2]) % 2) == 0 ?
            "La suma de los elementos de B es par" : "La suma de los elementos de B es impar");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
