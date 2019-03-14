using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public float speed;
    private Rigidbody2D rgi;
    public float despawn;
    public void Start() {
        rgi = GetComponent<Rigidbody2D>();
        
    }
    public void Update() {
        //rgi.AddForce(new Vector2(speed, 0));
        //Destroy(gameObject, despawn);
        //rgi.velocity = new Vector2(speed, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            return;
        }
        Destroy(gameObject);
    }

   

}
