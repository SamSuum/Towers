using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {
    LineRenderer line;
    Animator anim;
    [SerializeField] LayerMask grapplableMask;
    public GameObject swrd;
    //public Hook hk;
    [SerializeField] float maxDistance = 10f;
    //float dist=0;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 5f;

    [HideInInspector] public bool isGrappling = false;
    [HideInInspector] public bool isGrappled= false;
    [HideInInspector] public bool retracting = false;
    

    Vector2 target;

    private void Start() {
        line = GetComponent<LineRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update() {

        if (Input.GetMouseButton(0) && !isGrappling)
        {            
            //dist += grappleShootSpeed;               
            swrd.transform.Rotate(0,0,20.00f);
        }

        if (Input.GetMouseButtonUp(0) && !isGrappling) {
            StartGrapple();
        }

        if (retracting) {
            anim.SetBool("ISFLY", true);

            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);

            transform.position = grapplePos;

            line.SetPosition(0, transform.position);

            if (Vector2.Distance(transform.position, target) < 0.5f) {
                retracting = false;
                isGrappling = false;
                line.enabled = false; 
                //Debug.Log("Grappling over");               
            }
        }
        
    }

    private void StartGrapple() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);

        if (hit.collider != null) {
            isGrappling = true;
            target = hit.point;           
            line.enabled = true;
            line.positionCount = 2;
            StartCoroutine(Grapple());
        }
        //else Debug.Log("toofar?");
        //Debug.Log("StartGrapple");
    }

    IEnumerator Grapple() {
        float t = 0;
        float time = 10;        

        line.SetPosition(0, transform.position);        
        line.SetPosition(1, transform.position); 
        swrd.transform.position =line.GetPosition(1);

        Vector2 newPos;
        //Debug.Log("isGrappling");
        for (; t < time; t += grappleShootSpeed * Time.deltaTime) {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
            swrd.transform.position=line.GetPosition(1);
            yield return null;
        }
        
        line.SetPosition(1, target);
        //if (hk.grap)
        retracting = true;
        
        
        
    }
}
