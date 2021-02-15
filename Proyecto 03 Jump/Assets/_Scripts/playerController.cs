using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody)),RequireComponent(typeof(AudioSource))]

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMultiplier;
    private Vector3 startGravity;
    [SerializeField] private bool isOnGround = true;
    private bool _gameOver;

    public bool GameOver { get => _gameOver; }
    private Animator _animator;
    private Collider _collider;

    public ParticleSystem explosion;
    public ParticleSystem dirtDust;

    private const string SPEED_MULTIPLIER = "Speed Multiplier";
    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";

    private float speedMultiplier = 1f;

    [Range(0,1)]
    public float volumeFX;

    [System.Serializable]
    public class AudioClips
    {
        public AudioClip jumpSound, crashSound;
    }
    public AudioClips audioClips;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        startGravity = Physics.gravity;

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1);
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime / 100;
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger(JUMP_TRIG);

            _audioSource.PlayOneShot(audioClips.jumpSound, volumeFX);
        }

        if (isOnGround && !_gameOver)
        {
            dirtDust.Play();
        }
        else
        {
            dirtDust.Pause();
            dirtDust.Clear();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("GAME OVER!!!");

            explosion.Play();
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", Random.Range(1, 3));

            _audioSource.PlayOneShot(audioClips.crashSound, volumeFX);

            Invoke("RestartGame", 2.5f);
        }
        
    }

    void RestartGame()
    {

        speedMultiplier = 1;
        SceneManager.LoadSceneAsync("Prototype 3 desarrollando", LoadSceneMode.Single);
        Physics.gravity = startGravity;
        
    }


}
