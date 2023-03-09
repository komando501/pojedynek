using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{

    public float projectileSpeed;

    public Rigidbody2D theRB;

    public GameObject projectileEffect;

    // Start is called before the first frame update
    void Start()
    {
        theRB= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(projectileSpeed * transform.localScale.x, theRB.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(projectileEffect, transform.position, transform.rotation);
        Destroy(gameObject);        
    }
}
