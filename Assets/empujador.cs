using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empujador : MonoBehaviour
{
    public float force = 100, up = 10;
    
    private void OnTriggerEnter(Collider other)
    {
        
        var RB = other.GetComponent<Rigidbody>();
        
        //RB.AddExplosionForce(force, transform.position, transform.localScale.magnitude);

        var dir = (other.transform.position - transform.position).normalized;
        
        dir = new Vector3(dir.x, 0, dir.z);
        
        RB.AddForce(dir * force,ForceMode.Impulse);
    }
}
