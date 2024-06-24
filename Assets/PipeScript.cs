using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this controls the MOVEMENT and DESPAWNING of the pipes:
public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone;   // what is this relative to? (0, 0), the CENTER of the camera.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* ensure that pipes move at same speed across all devices.
           What is Vector3? */
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;  // Vector3.left is sugar syntax for Vector3(-1, 0, 0);
        // Vector3 is NOT some component property. It's an independent VECTOR object used here to calculate movement.

        if (transform.position.x < deadZone)    
        {
            Destroy(gameObject);    // get pipes out of memory. REMEMBER: gameObject is "this".
            Debug.Log("Pipe Deleted");
        }
    }
}
