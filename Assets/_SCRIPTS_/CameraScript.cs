using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform player; //Player to follow
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
        transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
    }
}
