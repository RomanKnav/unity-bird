using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    // reference to our logic script (increments score)
    public logicScript2 logic;

    // Reference to AudioSource component
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // it's that fucking easy to access scripts from other gameObjects!!!
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript2>();

        // Get the AudioSource component that THIS object has:
        audioSource = GetComponent<AudioSource>();
    }

    void PlayDing()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // this method runs whenever an object goes inside the box.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)        // check that the collision occurred on layer 3
        {
            logic.addScore(1);   // increment score 
            PlayDing();
        }
    }
}
