using UnityEngine;

public class MazeView : PlayerMovement
{
	public GameObject ViewCamera = null;
    public float speed = 6f;
    
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    PlayerHealth playerHealth;


    int floorMask;
    float camRayLength = 100f;


    // awake is called before start
    private void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerHealth = GetComponent <PlayerHealth>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        // if (ViewCamera != null) {
		// 	Vector3 direction = (Vector3.up*1+Vector3.back)*1;
		// 	RaycastHit hit;
		// 	Debug.DrawLine(transform.position,transform.position+direction,Color.red);
		// 	if(Physics.Linecast(transform.position,transform.position+direction,out hit)){
		// 		ViewCamera.transform.position = hit.point;
		// 	}else{
		// 		ViewCamera.transform.position = transform.position+direction;
		// 	}
		// 	ViewCamera.transform.LookAt(transform.position);
		// }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Move(h, v);
        Turning();
        Animating(h, v);
    }
    public override void Animating(float h, float v){
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    public override void Move(float h, float v){
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;



            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
        else{
        }
    }
}
