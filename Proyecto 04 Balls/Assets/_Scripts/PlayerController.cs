using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public bool gameOver;

    [SerializeField] private float moveForce;

    private float forwardInput;

    public GameObject focalPoint;

    public AudioSource _audioSource;

    [System.Serializable]
    public class PlayerSFX
    {
        public AudioClip collisionSFX;
    }

    public PlayerSFX _playerSFX;

    [Range(0,1)]
    public float volumeSFX;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //focalPoint = Gameobject.Find("Focal Point");
        _audioSource.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput,ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            _audioSource.PlayOneShot(_playerSFX.collisionSFX,volumeSFX);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            gameOver = true;
            SceneManager.LoadScene("Prototype 4");
        }
    }

}
