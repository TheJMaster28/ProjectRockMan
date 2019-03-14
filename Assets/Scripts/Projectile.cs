using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgi;
    public void Start() {
        rgi = GetComponent<Rigidbody2D>();
        
    }
    public void Update() {
        rgi.AddForce(new Vector2(speed, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        print("here");
        Destroy(gameObject);
    }


}
