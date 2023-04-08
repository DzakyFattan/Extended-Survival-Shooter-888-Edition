using UnityEngine;

public class PlayerMovementFirstPersonView : PlayerMovement
{
    public float speed = 6f;
    public float cameraSpeed = 150f;
    Vector3 movement;
    // TODO: refactor to use PlayerAnimationController
    Animator anim;
    Rigidbody playerRigidbody;
    PlayerHealth playerHealth;


    int floorMask;
    // float camRayLength = 100f;

    float prevMouseX;
    float prevMouseY;

    // awake is called before start
    private void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        // TODO: refactor to use PlayerAnimationController
        anim = GetComponent<Animator>();
        playerHealth = GetComponent <PlayerHealth> ();
        playerRigidbody = GetComponent<Rigidbody>();
        prevMouseX = Input.GetAxis("Mouse X");
        prevMouseY = Input.GetAxis("Mouse Y");
        // set rotation to 0, 0, 0
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void FixedUpdate(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }
    public override void Animating(float h, float v){
        bool walking = h != 0f || v != 0f;
        // TODO: refactor to use PlayerAnimationController
        anim.SetBool("IsWalking", walking);
    }

    // implement the abstract methods
    public override void Move(float h, float v){
        // based on the input and the player rotation, move the player
        // move forward based on the player rotation
        movement.Set(h, 0f, v);

        movement = transform.rotation * movement;
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(){
        // follow mouse movement

        // rotate on x and z axis according to mouse movement


        float differenceX = Input.GetAxis("Mouse X") - prevMouseX;
        float differenceY = Input.GetAxis("Mouse Y") - prevMouseY;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - differenceY, transform.rotation.eulerAngles.y + differenceX, 0);

    }
}
