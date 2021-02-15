using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    public bool hasPowerUp;
    private float waitTimePowerUp = 15;
    [SerializeField] private float indicatorPos = 0.5f;

    public GameObject[] powerUpIndicators;

    public AudioSource _sourceSFX;

    private float pithDecre= 0.5f;

    [Range(0, 1)]
    public float volumeSFX;

    [System.Serializable]
    public class SFX
    {
        public AudioClip pickUp,lessTime,timeOut;
    }
    public SFX _clipsSFX;
    private void Start()
    {
        _sourceSFX.GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Distance From the center of the GameObject, of the indicator
        foreach(GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + indicatorPos * Vector3.down;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            _sourceSFX.PlayOneShot(_clipsSFX.pickUp);
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        if (hasPowerUp)
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
            hasPowerUp = false;
        }
    }
}
