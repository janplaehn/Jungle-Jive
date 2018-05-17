using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderParticles : MonoBehaviour {
    public GameObject particle;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        foreach(ContactPoint2D c in collision.contacts)
        {
            Instantiate(particle, c.point, Quaternion.identity);
        }
        
        
    }

}
