using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static InitManager;
using static GameManager;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int myTurn;
    private bool isMyTurnSelected = false;
    PhotonView PV;
    public static PlayerController playerController;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        playerController = GetComponent<PlayerController>();
        IM.PlayerControllerList.Add(this);
        Debug.Log("추가!");
    }
    
    [PunRPC]
    void SetTurn(int turnNumber)
    {
        if(isMyTurnSelected == false)
        {
            myTurn = turnNumber;
            isMyTurnSelected = true;
        }
    }

    [PunRPC]
    void CheckMyTurn()
    {
        if(!PV.IsMine)
            return;

        if(myTurn == GM.GetCurTurn())
        {
            GM.txt.text = myTurn.ToString();
            Debug.Log("myTurn!");
        }
        else
        {
            GM.txt.text = "not my Turn";
            Debug.Log("not my Turn");
        }
    }
}
