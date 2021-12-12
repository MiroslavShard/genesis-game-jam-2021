using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject Hero;
    public Vector3 offset;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newCamPosition = new Vector3(playerTransform.position.y + offset.y, offset.y, playerTransform.position.z + offset.z);
        //transform.position = new Vector2(Hero.transform.position.x, transform.position.y);
        //transform.position = new Vector3(Vector3.Lerp(transform.position, playerTransform, speed * Time.deltaTime), transform.position.y, transform.position.z); ;
        //transform.position = Vector3.Lerp(offset.x, playerTransform + offset.y, speed * Time.deltaTime);
        Vector3.MoveTowards(transform.position, new Vector2(Hero.transform.position.x,1.7f), speed * Time.deltaTime);
    }
}
