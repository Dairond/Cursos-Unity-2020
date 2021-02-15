using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveForce;

    private Rigidbody _rigidbody;

    private GameObject player;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.gameOver)
        {
            Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
            _rigidbody.AddForce(lookDirection * moveForce, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
