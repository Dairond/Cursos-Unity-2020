using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;
    private float extraSpeed;
    public float speedMultiplier;

    public bool hasPowerup;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    public ParticleSystem dust;
    public bool gameOver;

    private float waitTimePowerUp = 15;
    [SerializeField] private float indicatorPos = 0.5f;

    public GameObject[] powerUpIndicators;
    public AudioSource _sourceSFX;
    private float pithDecre = 0.5f;

    [Range(0, 1)]
    public float volumeSFX;

    [System.Serializable]
    public class SFX
    {
        public AudioClip pickUp, lessTime, timeOut, collisionSFX;
    }
    public SFX _clipsSFX;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        extraSpeed = speed * speedMultiplier;
        _sourceSFX.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        // Add extra force to player in direction of the focal point
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(focalPoint.transform.forward * extraSpeed * Time.deltaTime,ForceMode.Impulse);
            dust.Play();
        }

        // Set powerup indicator position to beneath player
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + indicatorPos * Vector3.down;
        }

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            _sourceSFX.PlayOneShot(_clipsSFX.pickUp);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        if (hasPowerup)
        {
            foreach (GameObject indicator in powerUpIndicators)
            {
                indicator.gameObject.SetActive(true);
                yield return new WaitForSeconds(waitTimePowerUp / powerUpIndicators.Length);
                indicator.gameObject.SetActive(false);
                _sourceSFX.PlayOneShot(_clipsSFX.lessTime, volumeSFX);
                _sourceSFX.pitch += -pithDecre;
            }
            _sourceSFX.PlayOneShot(_clipsSFX.timeOut, volumeSFX);
            _sourceSFX.pitch = 2;
            hasPowerup = false;
        }
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            
            _sourceSFX.PlayOneShot(_clipsSFX.collisionSFX, volumeSFX);

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
