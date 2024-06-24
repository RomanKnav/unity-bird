using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    // reference to our logic script (increments score)
    public logicScript2 logic;

    // Start is called before the first frame update
    void Start()
    {
        // it's that fucking easy to access scripts from other gameObjects!!!
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this method runs whenever an object goes inside the box.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)        // check that the collision occurred on layer 3
        {
            logic.addScore(1);   // increment score 
        }
    }
}
