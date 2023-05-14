using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    GrappleHook gh;
    Animator anim;
    
    [SerializeField] float speed = 5f;

    float mx;
    float my;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gh = GetComponent<GrappleHook>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        //mx = Input.GetAxisRaw("Horizontal");
        //my = Input.GetAxisRaw("Vertical");
        if(!gh.isGrappling){
        gh.swrd.transform.position=transform.position;}
    }

    private void FixedUpdate() {
        if (!gh.retracting) {
            rb.velocity = new Vector2(mx, my).normalized * speed;
            anim.SetBool("ISFLY", false);
        } else {
            rb.velocity = Vector2.zero;            
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
