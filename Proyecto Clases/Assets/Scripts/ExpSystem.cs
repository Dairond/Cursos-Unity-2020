using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSystem : MonoBehaviour
{
    private int exp;
    private int nivel;
    private int nivelActual;
    private int expNecesaria;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        expNecesaria *= nivel;
        exp = 1000;
        nivelActual = (exp >= expNecesaria) ? ++nivel : nivel;

        Debug.Log(nivelActual);
    }
}
