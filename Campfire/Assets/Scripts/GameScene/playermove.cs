using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{


    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 0.5f; // 움직이는 속도
    public Vector3 target;

    // Use this for initialization
    void Start()
    {
        target = new Vector3(3.4f, 0.5f, -4.2f);
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
            animator.SetInteger("Movingdirection", 1);
            Debug.Log(LeftMove);
            //moveVelocity = new Vector3(-0.10f, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
    }
}
