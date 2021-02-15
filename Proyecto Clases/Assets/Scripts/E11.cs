using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E11 : MonoBehaviour
{
    private int vidas = 3;
    private int puntos = 0;
    public int tipoObjeto = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (tipoObjeto)
        {
            case 0:
                int moneda = 10;
                puntos += moneda;
                break;
            case 1:
                int corazon = 1;
                vidas += corazon;
                break;
            case 2:
                int oro = 30;
                puntos += oro;
                Debug.Log("Has encontrado oro!");
                break;
            case 3:
                int pinchos = 1;
                vidas -= pinchos;
                break;
            case 4:
                int bombas = 2;
                vidas -= bombas;
                break;
            default:
                Debug.Log("El tipo de objeto " + tipoObjeto + " no existe");
                break;
        }
        Debug.Log("Vidas: "+vidas);
        Debug.Log("Puntos: "+puntos);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
