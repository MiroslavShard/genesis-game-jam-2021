using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScr : MonoBehaviour
{
    public GameObject Pref;
    public GameObject Hero;
    bool once = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Hero" && once && Hero.transform.position.y < transform.position.y)
        {
            Instantiate(Pref, new Vector2(transform.position.x, transform.position.y + 1.2f), Quaternion.identity);
            
            once = false;
        }
    }
}
