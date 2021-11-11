using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{


    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool UpMove = false;
    public bool DownMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 0.5f; // 움직이는 속도
    public Vector3 target;
    public Vector3 target_x;
    public Vector3 target_z;

    // Use this for initialization
    void Start()
    {
        target = new Vector3(3.64f, -2f, 3.78f);
        animator = gameObject.GetComponent<Animator>();
        target_x = transform.position;
        target_z = transform.position;
    }// Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        {
            LeftMove = false;
            RightMove = false;
            UpMove = false;
            DownMove = false;
            animator.SetInteger("Movingdirection", 0);

        }
    }
    public void MovingRight()
    {
        target += new Vector3(1.1f, 0, 0);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        Debug.Log(target);
    }
    public void movingLeft()
    {
        target += new Vector3(-1.1f, 0, 0);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        Debug.Log(target);
    }
    public void MovingUp()
    {
        target += new Vector3(0, 0, 1.1f);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        Debug.Log(target);
    }
    public void MovingDown()
    {
        target += new Vector3(0, 0, -1.1f);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        Debug.Log(target);
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
}
