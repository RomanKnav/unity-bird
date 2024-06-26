using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // this is public, so it can be accessed from outside script
    public Rigidbody2D myRigidBody;
    public float flapStrength;          // any public vars are visible in the inspector
    public logicScript2 logic;          // "logic" is simply the name for our logicScript

    public bool birdIsAlive = true;

    public bool isBird = false;

    private Camera mainCamera;
    private float cameraBottom;
    private float cameraTop;

    // Start is called before the first frame update
    void Start()
    {
        // SHIT IN HERE RUNS AS SOON AS THE GAME STARTS. Runs only once. gameObject is basically "this":

        mainCamera = Camera.main;

        cameraTop = mainCamera.transform.position.y + mainCamera.orthographicSize;
        cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript2>();
        // what's the point of having this when logic is already defined above?

    }

    // Update is called ONCE PER FRAME.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;  // shorthand for Vector(0, 1)
            // how's this work? shouldn't bird keep going up as spacebar is held down?
        }

        float gameObjectY = transform.position.y;

        if (gameObjectY < cameraBottom || gameObjectY > cameraTop)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    // the BIRD will be the trigger. This occurs when it collides with ANYTHING:
    // This method is automatically called by Unity when the GameObject with this script attached collides with another GameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
