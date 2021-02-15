using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public bool outOfBounds;

    public float floatForce;
    private float gravityModifier = 1.7f;
    private Vector3 startGravity;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private float topRange = 14;
    private float bottomRange = 2;

    // Start is called before the first frame update
    void Start()
    {

        startGravity = Physics.gravity;

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && !outOfBounds)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (transform.position.y >= topRange)
        {
            transform.position = new Vector3(transform.position.x, topRange, transform.position.z);
            outOfBounds = true;
        }
        else
        {
            outOfBounds = false;
        }

        if (transform.position.y < bottomRange && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Invoke("RestartGame", 2.5f);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }
    void RestartGame()
    {

        SceneManager.LoadSceneAsync("Challenge 3", LoadSceneMode.Single);
        Physics.gravity = startGravity;
    }
}
