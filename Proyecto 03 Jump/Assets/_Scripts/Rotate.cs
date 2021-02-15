using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 60;
    [SerializeField] private float speed = 1;

    private playerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.localPosition+= Vector3.left * speed * Time.deltaTime;

            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
