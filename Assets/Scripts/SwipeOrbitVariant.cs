using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/** Edit -> Project Settings -> Input
 *	Add axis named "PointerX"
 *  Set type to Mouse Movement
 */ 
public class SwipeOrbit : MonoBehaviour
{
    private float axisx;
    public  float speed   = 0.25f;
    public  float damping = 1.025f;

    void Update()
    {
        if(axisx != 0)
        {
            axisx /= damping;
            axisx = Mathf.Abs(axisx) < 0.01 ? 0 : axisx;
            transform.Rotate(0, axisx * speed, 0);
        }        
    }
    
    private void OnMouseDrag()
    {
        axisx += Input.GetAxis("PointerX") * 0.05f;
    } 
       
}