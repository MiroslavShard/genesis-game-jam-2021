using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForce : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    bool a = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform") rb.AddForce(new Vector3(0, 1, 0) * jumpForce);

    }

}
