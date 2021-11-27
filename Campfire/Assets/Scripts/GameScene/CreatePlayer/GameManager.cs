using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text txt;
    public int curTurn = 0;
    public int playerCount;

    public GameObject mine;
    public PlayerController myController;
    public List<PlayerController> PlayerControllerList = new List<PlayerController>();

    public static GameManager GM;
    PhotonView PV;
    void Awake()
    {
        GM = this;
        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        txt.text = "curTurn : " + curTurn.ToString() + " myTurn:" + myController.myTurn.ToString();
    }

    [PunRPC]
    public void SetPlayerCount(int p)
    {
        playerCount = p;
    }
    public void SetValue(List<PlayerController> pl) //클래스는 동기화 불가 -> 나중에 stream 이용할것
    {
        PlayerControllerList = pl;
    }

    [PunRPC]
    public void NewTurnStart()
    {
        curTurn = (curTurn+1) % playerCount;
        UiManager.UM.LImitTime = 10f; //시간제한 초기화
        Inventory.IM.itemSlot[0].interactable = false; //버튼 비활성화
        Inventory.IM.itemSlot[1].interactable = false; //버튼 비활성화
        HeartManager.HM.HeartMove();
        myController.CheckMyTurn();
        
    }

    [PunRPC]
    public void RPC_NewTurnStart()
    {
        PV.RPC("NewTurnStart", RpcTarget.All);
    }

    public int GetCurTurn()
    {
        return curTurn;
    }

    public void SetTarget(int i)
    {
        myController.SetTarget(i);
    }

    public void Move()
    {
        _ = myController.Move();
    }
}
