using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Vector3[] arr = {
        new Vector3(1.1f, 0, 0),
        new Vector3(-1.1f, 0, 0),
        new Vector3(0, 0, 1.1f),
        new Vector3(0, 0, -1.1f)
    };

    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool UpMove = false;
    public bool DownMove = false;
    public bool isMoving = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 0.5f; // 움직이는 속도
    public Vector3 countMove;
    public Vector3 target_x;
    public Vector3 target_z;

    public GameObject planePrefab;
    public GameObject plane;


    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        countMove = new Vector3(0f, 0f, 0f);
        target_x = transform.position;
        target_z = transform.position;

        plane = Instantiate(planePrefab, transform);
        plane.transform.position += new Vector3(-3.5f, 1f, 0);
        plane.SetActive(false);
    }// Update is called once per frame
    void Update()
    {

        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, (target_x + target_z)/2, 1f * Time.deltaTime);
        }
        /*
        if (transform.position)
        {
            isMoving = false;
            
            LeftMove = false;
            RightMove = false;
            UpMove = false;
            DownMove = false;
            animator.SetInteger("Movingdirection", 0);
            

        }
    */
    }

    float CountMove(Vector3 countMove)
    {
        return Mathf.Abs(countMove.x) + Mathf.Abs(countMove.z);
    }

    public void planePos(int i)
    {
        Vector3 nextCountMove = countMove + arr[i];
        if (CountMove(nextCountMove) < 5)
        {
            countMove = nextCountMove;
            if(i>1)
            {
                target_z += 2*arr[i];
            }
            else
            {
                target_x += 2*arr[i];
            }
            
            plane.transform.position += arr[i];
        }
        Debug.Log(countMove);

    }

    public void Bulddeok()
    {
        plane.SetActive(true);
    }

    public void Move()
    {
        plane.SetActive(false);
        isMoving = true;
    }














    public void MovingRight()
    {
        Vector3 nextCountMove = countMove + new Vector3(1.1f, 0, 0);
        if (CountMove(nextCountMove) < 5)
        {
            countMove = nextCountMove;
            target_x += new Vector3(1.1f, 0, 0);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        }
        Debug.Log(countMove);

    }
    public void movingLeft()
    {
        Vector3 nextCountMove = countMove + new Vector3(-1.1f, 0, 0);
        if (CountMove(nextCountMove) < 5)
        {
            countMove = nextCountMove;
            target_x += new Vector3(-1.1f, 0, 0);
        }
        Debug.Log(countMove);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
       
    }
    public void MovingUp(int i)
    {
        Vector3 nextCountMove = countMove + new Vector3(0, 0, 1.1f);
        if (CountMove(nextCountMove) < 5)
        {
            countMove = nextCountMove;
            target_z += new Vector3(0, 0, 1.1f);
        }
        Debug.Log(countMove);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);

    }
    public void MovingDown()
    {
        Vector3 nextCountMove = countMove + new Vector3(0, 0, -1.1f);
        if (CountMove(nextCountMove) < 5)
        {
            countMove = nextCountMove;
            target_z += new Vector3(0, 0, -1.1f);
        }
        Debug.Log(countMove);
        //animator.SetInteger("Movingdirection", 1);
        // moveVelocity = new Vector3(+0.10f, 0, 0);
        //transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);

    }
    
}
