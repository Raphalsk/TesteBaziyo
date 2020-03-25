using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFloor : MonoBehaviour
{
    private GameObject Collider;
    private Run running;
    

    void Start()
    {
       


    }

    public void OnCollisionEnter2D(Collision2D Collider)
    {
        if (Collider.collider.tag == "Floor")
        {
            
            Run.IsGrounded = true;
            
        }
    }
    public void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.collider.tag == "Floor")
        {
           
            Run.IsGrounded = false;
            
        }
        
    }
}
