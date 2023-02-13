using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPOS;

    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() //late update is called when all update computations have been completed
    {
        tempPOS = transform.position; //camera position
        tempPOS.x = player.position.x;

        if (tempPOS.x < minX) 
            tempPOS.x = minX;
        
        if (tempPOS.x > maxX)
            tempPOS.x = maxX;
        
        transform.position = tempPOS; //reassign camera position on x-aixs to player position on x-axis
    }
}
