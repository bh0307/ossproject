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

    // Use this for initialization
    void Start()
    {
        target = new Vector3(3.64f, -2f, 3.78f);
        animator = gameObject.GetComponent<Animator>();
    }// Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
           movingLeft();
        }
        if (RightMove)
        {
            MovingRight();
         }
        if (UpMove)
        {
            MovingUp();
         }
        if (DownMove)
         {
            MovingDown();
        }
        if (transform.position == target)
        {
            LeftMove = false;
            RightMove = false;
            UpMove = false;
            DownMove = false;
            animator.SetInteger("Movingdirection", 0);
        }
    }
    void MovingRight()
    {
            target =transform.position + new Vector3(1.1f, 0, 0);
            animator.SetInteger("Movingdirection", 1);
           // moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
    void movingLeft()
    {
            target =transform.position + new Vector3(-1.1f, 0, 0);
            animator.SetInteger("Movingdirection", 1);
           // moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
    void MovingUp()
    {
    target =transform.position + new Vector3(0, 1.1f, 0);
            animator.SetInteger("Movingdirection", 1);
           // moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
    void MovingDown()
    {
    target =transform.position + new Vector3(0, -1.1f, 0);
            animator.SetInteger("Movingdirection", 1);
           // moveVelocity = new Vector3(+0.10f, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }

}
