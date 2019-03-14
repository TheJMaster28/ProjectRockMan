using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rgi;
    public float jumpSpeed;
    public GameObject mainCamera;
    public float speed;
    public float projectileSpeed;
    public float maxSpeed;
    private Vector3 offset;
    private bool onGround = false;
    public PhysicsMaterial2D PlayerDefault;
    public PhysicsMaterial2D PlayerJump;
    public BoxCollider2D PlayerPhysicalHitbox;
    public GameObject emit;
    public Rigidbody2D projectile;
    public float time;
    private float timeTracker;
    enum MovementState {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    private MovementState state;
    private Vector3 statePosion;
    // Start is called before the first frame update
    void Start()
    {
        rgi = gameObject.GetComponent<Rigidbody2D>();
        offset = mainCamera.transform.position - transform.position;
        timeTracker = time;
        state = MovementState.RIGHT;
        statePosion = emit.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        print(onGround);
        if ( Input.GetKey("a") && !Input.GetKey("d") ) {
            rgi.AddForce(new Vector2(-speed, 0));
            emit.transform.position = transform.position - statePosion;
            state = MovementState.LEFT;
        }  
        if (Input.GetKey("d") && !Input.GetKey("a")) {
            rgi.AddForce(new Vector2(speed, 0));
            state = MovementState.RIGHT;
            emit.transform.position = transform.position + statePosion;
        }
        if (Input.GetKey("w") && !Input.GetKey("s") ) {
            state = MovementState.UP;
            emit.transform.position = new Vector3(transform.position.x, transform.position.y + statePosion.y, 0);
        }
        mainCamera.transform.position = mainCamera.transform.position + offset; 
        
        if ( Input.GetKeyDown("space") && onGround) {
            rgi.AddForce(new Vector2(0, jumpSpeed));
        } 
        if ( onGround) {
            PlayerPhysicalHitbox.sharedMaterial = PlayerDefault;
        }
        else {
            PlayerPhysicalHitbox.sharedMaterial = PlayerJump;
        }
        timeTracker -= Time.deltaTime;
        //print(timeTracker);
        if ( timeTracker <= 0.0f) { timeTracker = 0.0f;  }

        if ( Input.GetKey("e")) {
            
            if (timeTracker <= 0.0f) {
                Rigidbody2D ip = Instantiate(projectile, emit.transform.position, Quaternion.identity) as Rigidbody2D;
                if ( state == MovementState.RIGHT ) { ip.velocity = new Vector2(projectileSpeed, 0); }
                if ( state == MovementState.LEFT ) { ip.velocity = new Vector2(-projectileSpeed, 0); }
                if ( state == MovementState.UP ) { ip.velocity = new Vector2(0, projectileSpeed); } 
                timeTracker = time;
            }

        }
    }
    private void FixedUpdate() {
        if ( rgi.velocity.x > maxSpeed ) {
            rgi.velocity = new Vector2(maxSpeed, rgi.velocity.y); 
        }
        if (rgi.velocity.x < -maxSpeed) {
            rgi.velocity = new Vector2(-maxSpeed, rgi.velocity.y);
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
