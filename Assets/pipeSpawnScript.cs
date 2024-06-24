using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;

    // these are private, so they won't show in the inspector:
    private float timer = 0;

    // used for creating random y heights for pipes:
    private float heightOffset = 6;    // determines possible RANGE of heights.

    // Start is called before the first frame update
    void Start()
    {
        // ensure pipes spawn immediately on start. Pretty wierd, without it pipes take a while to spawn.
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        // gives us high point and low point to spawn each pipe at:
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // crazy: there are multiple VERSIONs of this built-in method for creating game objects:
        // this will spawn the obj on top of the spawner:
        // transform.position referes to y CENTER of object:
        // Instantiate(pipe, transform.position, transform.rotation);      // if greater than spawn rate, spawn new obj and reset timer

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        // I dont understand? Remember, this code works on the PIPE PARENT, not individual pipes. The distance between the two pipes will always be the same
    }
}
