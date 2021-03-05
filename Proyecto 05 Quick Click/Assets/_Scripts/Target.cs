using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private float minForce = 12,
    maxforce = 16,
    maxTorque = 10, 
    xRange = 4, 
    ySpawnPos = -6;

    private GameManager _gameManager;

    [Range(-1000, 1000),SerializeField] private int pointValue;

    public ParticleSystem explosionParticle;

    private int neutralValue;
    public int neutralEffect = 2;
    [Range(0,2)] private int _objectType;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), 
        RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();

        _gameManager = FindObjectOfType<GameManager>();
        if(gameObject.CompareTag("Neutral"))
        {
            _objectType = 1;
        }
        else if(gameObject.CompareTag("PowerUp"))
        {
            _objectType = 2;
        }
        else if(gameObject.CompareTag("Good") ^ gameObject.CompareTag("Bad"))
        {
            _objectType = 0;
        }
    }
    
    /// <summary>
    /// Generates a random vector of force in 3D
    /// </summary>
    /// <returns>A random force up between the minimun and maximun force</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxforce);
    }
    /// <summary>
    /// Generates a random torque between -maxTorque and maxTorque
    /// </summary>
    /// <returns>A random value of torque between -maxTorque and maxTorque</returns>
    private float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    /// <summary>
    /// Generates a random position between the minimun and maximun range
    /// </summary>
    /// <returns>A random position between the minimun and maximun range</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    private void OnMouseDown()
    {
        if (_gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            _gameManager.objectCount++; //Count the amount of object destroyed during the game
            ObjectType(_objectType);
            Instantiate(explosionParticle,
                transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            if(gameObject.CompareTag("Good"))
            {
                _gameManager.GameOver();
            }
        }
    }
    
    /// <summary>
    /// Determine the function of the target according to his type
    /// </summary>
    /// <param name="typeOBject">Type of the object</param>
    private void ObjectType(int typeOBject)
    {
        if(typeOBject==1)
        {
            if (_gameManager.neutralCount > 0 & (_gameManager.neutralScore > 0 | _gameManager.neutralScore < 0))
            {
                float neutralDiv = _gameManager.neutralCount / neutralEffect;
                neutralValue = (int)(_gameManager.neutralScore / neutralDiv);
            }
            _gameManager.UpdateScore(neutralValue);
            _gameManager.neutralScore = 0;
            _gameManager.neutralCount = 0;
        }
        else if (typeOBject==0)
        {
            _gameManager.UpdateScore(pointValue);
            _gameManager.neutralCount++;
        }
    }
}
