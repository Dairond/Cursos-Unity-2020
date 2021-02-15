using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Music : MonoBehaviour
{
    [Header("Background Music")]
    public AudioSource music;
    [System.Serializable]
    public class backgroundMusics
    {
        public AudioClip Music1;
        public AudioClip Music2;
        public AudioClip Music3;

    }
    public backgroundMusics _BackgroundMusics;
    


    private playerController _playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player")
            .GetComponent<playerController>();

        if (!_playerController.GameOver)
        {
            music.clip = _BackgroundMusics.Music1;
            music.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.GameOver)
        {
            music.Pause();
        }

    }
}
