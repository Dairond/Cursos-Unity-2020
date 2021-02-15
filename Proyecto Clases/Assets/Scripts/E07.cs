using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E07 : MonoBehaviour
{
    public int[] valores= { 0, 0, 0, 0, 0 };
    

    // Start is called before the first frame update
    void Start()
    {

        valores[0] = 1;
        valores[1] = 2;
        valores[2] = valores[0] + valores[1];
        valores[3] = valores[1] + valores[2];
        valores[4] = valores[2] + valores[3];

        Debug.Log(valores[0] + ", " + valores[1] + ", " + valores[2]
            + ", " + valores[3] + ", " + valores[4]);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
