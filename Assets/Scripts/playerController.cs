using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rgi;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rgi = gameObject.GetComponent<Rigidbody2D>();


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
    }
}
