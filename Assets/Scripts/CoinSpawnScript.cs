using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{

    public GameObject coin;
    public float spawnRate = 1;

    private float timer = 0;
    public float heightOffset = 10f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timer < spawnRate)
        {

            timer = timer + Time.deltaTime;


        } else 
        {
            spawnPipe();
            timer = 0;
        }



    }

    void spawnPipe() 
    {
        float lowestPoint = -1f;
        float highestPoint = 3f;

        Instantiate(coin, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }
}
