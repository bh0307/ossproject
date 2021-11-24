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
    public List<PlayerController> PlayerControllerList = new List<PlayerController>();

    public static GameManager GM;
    PhotonView PV;
    void Awake()
    {
        GM = this;
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        txt.text = "curTurn : " + curTurn.ToString() + " myTurn:" + mine.GetComponent<PlayerController>().myTurn.ToString();
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
        /*
        GetComponent<PhotonView>().RPC("CurTurnSync", RpcTarget.All);

        for(int i=0; i<playerCount; i++)
        {
            PlayerControllerList[i].GetComponent<PhotonView>().RPC("CheckMyTurn", RpcTarget.All);
            //각 클라이언트에서 컨트롤러 리스트가 다르지만 적어도 한번 순회함은 변함 없음
        }
        */

        curTurn = (curTurn+1) % playerCount;
        mine.GetComponent<PlayerController>().CheckMyTurn();
        //mine.GetComponent<PhotonView>().RPC("CheckMyTurn", RpcTarget.All);
        
    }

    [PunRPC]
    public void RPC_NewTurnStart()
    {
        GetComponent<PhotonView>().RPC("NewTurnStart", RpcTarget.All);
    }

    public int GetCurTurn()
    {
        return curTurn;
    }

    /*
    public void GameStart()
    {
        for(int i=0; i<playerCount; i++)
        {
            PlayerControllerList[i].GetComponent<PhotonView>().RPC("CheckMyTurn", RpcTarget.All);
            
        }
    }
    */
}
