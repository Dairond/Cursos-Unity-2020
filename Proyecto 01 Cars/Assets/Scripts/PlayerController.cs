using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Propiedades
    //[HideInInspector]
    [Range(0, 20), SerializeField, Tooltip("Velocidad lineal máxima del vehiculo")]
    private float speed = 10f;
    
    [Range(0, 45), SerializeField, Tooltip("Velocidad de giro del vehiculo")]
    private float turnspeed = 30f;
    private float horizontalInput, verticalInput;

    [Header("Audio Source")]
    
    public AudioSource mainAudioSource;

    [System.Serializable]
    public class soundClips
    {
        public AudioClip accelerationSound;
        public AudioClip startSound;
        public AudioClip lowOffSound;
    }
    public soundClips SoundClips;

    private bool startSoundHasPlayed = false;
    private bool accelerationSoundHasPlayed = false;
    private bool lowOffSoundHasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Esto es el metodo Start del "+gameObject.name);

        


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Esto es el metodo Update del "+gameObject.name);
        verticalInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log("Movimiento horizontal: " + horizontalInput);

        this.transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);//0,0,1
        transform.Rotate(turnspeed * Time.deltaTime * Vector3.up*horizontalInput);

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") < 0.5)
        {
            //Sonido de encendido del vehiculo
            if (!startSoundHasPlayed)
            {
                mainAudioSource.clip = SoundClips.startSound;
                mainAudioSource.Play();
                startSoundHasPlayed = true;

            }
            
            
        }
        else if (Input.GetAxis("Vertical") >= 0.5 && Input.GetAxis("Vertical") < 1)
        {
            //Sonido de movimiento lento del vehiculo
            if (!lowOffSoundHasPlayed)
            {
                mainAudioSource.clip = SoundClips.lowOffSound;
                mainAudioSource.Play();
                lowOffSoundHasPlayed = true;
            }
            
        }
        else if (Input.GetAxis("Vertical") == 1)
        {
            if (!accelerationSoundHasPlayed)
            {

                mainAudioSource.clip = SoundClips.accelerationSound;
                mainAudioSource.Play();
                accelerationSoundHasPlayed = true;

            }
            
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            if (!lowOffSoundHasPlayed)
            {
                mainAudioSource.clip = SoundClips.lowOffSound;
                mainAudioSource.Play();
                lowOffSoundHasPlayed = true;
            }
        }
        else
        {
            mainAudioSource.Stop();
            accelerationSoundHasPlayed = false;
            lowOffSoundHasPlayed = false;
            
        }
    }
}
