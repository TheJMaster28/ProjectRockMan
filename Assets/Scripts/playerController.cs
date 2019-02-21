using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rgi;
    public GameObject mainCamera;
    public float speed;
    public float maxSpeed;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rgi = gameObject.GetComponent<Rigidbody2D>();
        offset = mainCamera.transform.position - transform.position;


    }

    // Update is called once per frame
    void Update()
    {
      if ( Input.GetKey("a") && !Input.GetKey("d") ) {
            rgi.AddForce(new Vector2(-speed, 0));
        }  
      if (Input.GetKey("d") && !Input.GetKey("a")) {
            rgi.AddForce(new Vector2(speed, 0));
        }
        mainCamera.transform.position = mainCamera.transform.position + offset; 

    }
    private void FixedUpdate() {
        if ( rgi.velocity.magnitude > maxSpeed ) {
            rgi.velocity = rgi.velocity.normalized * maxSpeed; 
        }
    }
}
