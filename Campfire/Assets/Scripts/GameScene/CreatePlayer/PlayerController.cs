using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static InitManager;
using static GameManager;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int myTurn;
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
    public void CheckMyTurn()
    {
        if(!PV.IsMine)
            return;
        
        Debug.Log(GM.GetCurTurn() + "현재 턴");
        Debug.Log(gameObject.GetComponent<PlayerController>().myTurn + "나의 턴");

        if(myTurn == GM.GetCurTurn())
        {
            Debug.Log("myTurn!");
            UiManager.UM.MyTurnStart();
        }
        else
        {
            Debug.Log("not my Turn");
            UiManager.UM.OthersTurn();
        }
    }
}
