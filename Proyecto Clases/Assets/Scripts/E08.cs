using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E08 : MonoBehaviour
{

    private int edad = 31;

    // Start is called before the first frame update
    void Start()
    {
        bool dentroDelIntervalo = (edad >= 18) && (edad <= 30);

        bool fueraDelIntervalo = (edad < 18) || (edad > 30);

        Debug.Log("¿esta el valor " + edad + " entre 18 y 30? " + dentroDelIntervalo);

        Debug.Log("¿esta el valor " + edad + " fuera de [18, 30]? " + fueraDelIntervalo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
