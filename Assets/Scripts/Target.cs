using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12, maxSpeed = 16, maxTorque = 10, xRange = 4, ySpawnPos = -2;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque( RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(5);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    



}
