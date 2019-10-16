using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    int walkSpeed = 7;
    int jumpHeight = 800;
    public bool inAir = true;

    Ray groundRay; //For checking the ground below
    void Awake(){
        rb = GetComponent<Rigidbody>();
        if(rb == null)
            Debug.LogError("No Rigidbody found in player!");
    }

    // Start is called before the first frame update    
    void Start()
    {
        print("Yarg");
    }

    // Update is called once per frame
    void Update()
    {
        drawRays();
        checkMovement();
        checkFall();
    }

    void checkMovement(){
        Vector3 newVel = rb.velocity;
        if(Input.GetKey("left")){
            Vector3 temp = -transform.right*walkSpeed;
            temp.y = newVel.y;
            newVel = temp;
        }
        if(Input.GetKey("right")){
            Vector3 temp = transform.right*walkSpeed;
            temp.y = newVel.y;
            newVel = temp;
        }
       //     rb.MovePosition(transform.position + transform.right*.2f);
        rb.velocity = newVel;

        //Jump
        if(Input.GetKeyDown("up") && !inAir){
            inAir = true;
            rb.AddForce(transform.up*jumpHeight);
        }
    }

    void checkFall(){
        if(transform.position.y < -15)
            perish();
    }

    void drawRays(){
        groundRay = new Ray (transform.position, -transform.TransformDirection(transform.up)*1.5f);
        Debug.DrawRay (transform.position, -transform.TransformDirection(transform.up)*1.5f, Color.cyan);
    }

    void perish(){
        CameraScript.cameraScript.stopFollowing();
        Invoke("loadLevel", 3);
    }

    void loadLevel(){
        Application.LoadLevel(Application.loadedLevel);
    }

    //Unity's built-in
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Ground"))
            inAir = false;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Item")){
            ScoreKeeper.sk.addScore(10);
            Destroy(other.gameObject);
        }
    }

    //Unity's built-in
    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Ground"))
            inAir = true;
    }
}
