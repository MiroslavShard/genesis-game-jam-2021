using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MarioMove : MonoBehaviour
{
    Vector2 moveVelocity;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public int countJump;
    int startJump;
    bool isColl = false;
    Vector2 startPos;
    bool isLeft = true;
    private Animator anim;
    public Camera Camera;
    public int CoinCount;
    public Text Coins;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startJump = countJump;
        startPos = new Vector2(transform.position.x,transform.position.y);
        //Camera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);
        moveVelocity = move.normalized * speed;

        if(Input.GetKeyDown(KeyCode.Space) && countJump > 0) 
        {
            anim.SetBool("isJump", true);
            rb.AddForce(new Vector2(0,500 * jumpForce ));
            //rb.velocity+= Vector2.up * Physics2D.gravity.y * Time.deltaTime * 10000;
            
            //transform.Translate(Vector2.up * jumpForce );
            Invoke("Jump",0.3f);
            countJump--;
        }
        if (transform.position.y < -6) Back();
        //

        if(Input.GetKey(KeyCode.D))
        {
            isLeft = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) anim.SetBool("isWalk",true);

        else anim.SetBool("isWalk", false);
        //
        if (isLeft) transform.localScale = new Vector3(1.7f, 1.7f, 1);
        else transform.localScale = new Vector3(-1.7f, 1.7f, 1);




    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(coll.gameObject.tag == "Die" && transform.position.y - 0.5f < coll.gameObject.transform.position.y)
        {
            Invoke("Back", 0.2f);
        }
        if (coll.gameObject.tag == "Die" && transform.position.y - 0.5f > coll.gameObject.transform.position.y)
        {
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Box")
        {
            countJump = 1;
        }
        if(coll.gameObject.tag == "Enemy")
        {
            if(transform.position.y > coll.gameObject.transform.position.y)
            {
                Destroy(coll.gameObject);
            }
        }
        if(coll.gameObject.tag == "Box")
        {
            Invoke("UpDown", 0.3f);
            //Camera.transform.position = new Vector2(Camera.transform.position.x + 0.005f, Camera.transform.position.y);  
        }
        if(coll.gameObject.tag == "Coin")
        {
            Call();
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Finish")
        {
            //Finish LVL
            Destroy(coll.gameObject);
            ApplicationManager.LoadLevel("BossFight");
        }
    }


    //
    void Back()
    {
        transform.position = startPos;
    }
    void UpDown()
    {
        //Camera.transform.position = new Vector2(Camera.transform.position.x - 0.005f, Camera.transform.position.y);
    }
    void Call()
    {
        CoinCount++;
        Coins.text = CoinCount.ToString();  
    }
    void Jump()
    {
        anim.SetBool("isJump", false);
    }
}
