﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/* Each agent will find neighbours using the physics system to check for
 other objects within its local radius; 
 Keeping the collider type generic instead of specifying 'CircleCollider2D' because, 
 although flock agents will use a circle collider, we could also use box colliders if needed (maybe for drones visual)
 */
[RequireComponent(typeof(Collider2D))] 
public class FlockAgent : MonoBehaviour
{
    public bool callStop = false;
    

    // Access the collider without ever being able to assign to it (after starting it up in Start())
    Collider2D _agentCollider;
    public Collider2D AgentCollider
    { 
        get { return _agentCollider; }
        set => _agentCollider = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        AgentCollider = GetComponent<Collider2D>();
    }

    /*
     * Method to indicate each agents new position to relocate to once
     * we've calculated the movement through the flock behaviours;
     * 'newPosition' is the offset position the agent will be moving to 
     */
    public void Move(Vector2 newPosition)
    {
        //turn agent to direction it will move towards
        //Use transform.forward if code is changed to 3D
        transform.up = newPosition; 
        
        /*
         * move to new position;
         * Time.deltaTime ensures we have constant movement regardless of Framerate;
         * Cast newPosition to Vector3 to avoid errors
         * because transform.position expects Vector 3 and newPosition is a Vector2 object
         */
        transform.position += (Vector3)newPosition * Time.deltaTime;

    }
    
}
