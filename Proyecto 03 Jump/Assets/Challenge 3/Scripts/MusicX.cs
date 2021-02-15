using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicX : MonoBehaviour
{
    [Header("Background Music")]
    public AudioSource music;
    [System.Serializable]
    public class backgroundMusics
    {
        public AudioClip Music1;
    }
    public backgroundMusics _BackgroundMusics;
    private PlayerControllerX _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerControllerX>();

        if (!_playerController.gameOver)
        {
            music.clip = _BackgroundMusics.Music1;
            music.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.gameOver)
        {
            music.Pause();
        }

    }
}
