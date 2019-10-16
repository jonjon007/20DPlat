using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript cameraScript;
    Transform player; //Player to follow
    bool followingPlayer = true;
    
    void Awake(){
        if(cameraScript != null)
            Destroy(gameObject);
        cameraScript = this;
    }
    
    // Start is calle   d before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player == null)
            Debug.LogError("Camera couldn't find the player!");
        else
            Debug.Log("Yarg from Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(followingPlayer)
            transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
    }

    public void stopFollowing(){
        followingPlayer = false;
    }
}
