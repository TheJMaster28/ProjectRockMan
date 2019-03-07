using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rgi;
    public float jumpSpeed;
    public GameObject mainCamera;
    public float speed;
    public float maxSpeed;
    private Vector3 offset;
    private bool onGround = false;
    public PhysicsMaterial2D PlayerDefault;
    public PhysicsMaterial2D PlayerJump;
    public BoxCollider2D PlayerPhysicalHitbox;
    // Start is called before the first frame update
    void Start()
    {
        rgi = gameObject.GetComponent<Rigidbody2D>();
        offset = mainCamera.transform.position - transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        print(onGround);
        if ( Input.GetKey("a") && !Input.GetKey("d") ) {
            rgi.AddForce(new Vector2(-speed, 0));
        }  
        if (Input.GetKey("d") && !Input.GetKey("a")) {
            rgi.AddForce(new Vector2(speed, 0));
        }
        mainCamera.transform.position = mainCamera.transform.position + offset; 
        
        if ( Input.GetKeyDown("space") && onGround) {
            print(onGround);
            
            rgi.AddForce(new Vector2(0, jumpSpeed));
        } 
        if ( onGround) {
            PlayerPhysicalHitbox.sharedMaterial = PlayerDefault;
        }
        else {
            PlayerPhysicalHitbox.sharedMaterial = PlayerJump;
        }
    }
    private void FixedUpdate() {
        if ( rgi.velocity.magnitude > maxSpeed ) {
            rgi.velocity = rgi.velocity.normalized * maxSpeed; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        onGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision) {
        onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        onGround = false; 
    }
}
