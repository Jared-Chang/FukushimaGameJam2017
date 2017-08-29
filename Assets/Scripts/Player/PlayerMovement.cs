using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;          
    
    Vector3 movement;                   
    Animator anim;                      
    Rigidbody playerRigidbody;          
    int floorMask;                      
    float camRayLength = 100f;          

    void Awake()
    {
        floorMask = LayerMask.GetMask("Ground");

        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
    }


    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        
        movement = movement.normalized * speed * Time.deltaTime;
        
        playerRigidbody.MovePosition(transform.position + movement);
    }
}