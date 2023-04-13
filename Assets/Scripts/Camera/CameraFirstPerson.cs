using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFirstPerson : MonoBehaviour
{   public Transform target;
    public float smoothing = 100f;
    Vector3 offset;
    // Start is called before the first frame update

    // camera perfect location for this character is at 0.04, 0.84, -0.32
    void Start()
    {

        
        offset = transform.position - target.position;
        // lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        // move camera to player except for y axis
        transform.position = new Vector3(target.position.x, 1.1f, target.position.z);

        // move cursor to center of screen
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        // change the camera position to in front of the player
        transform.position = new Vector3(target.position.x, 1.1f, target.position.z);



        

        // change the camera rotation to match the player rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothing * Time.deltaTime);




    }
}
