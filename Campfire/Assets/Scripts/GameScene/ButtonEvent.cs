using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{

    GameObject PlayerObj;
    playermove Playermove;

    // Use this for initialization
    void Start()
    {
        PlayerObj = GameObject.Find("PlayerObj");
       Playermove = PlayerObj.GetComponent<playermove>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void left()
    {
        Playermove.LeftMove = true;
    }
 
    public void right()
    {
        Playermove.RightMove = true;
    }
}
    