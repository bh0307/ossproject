using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text txt;
    private int curTurn = 0;
    private int playerCount;
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

    public void SetValue(int p, List<PlayerController> pl)
    {
        playerCount = p;
        PlayerControllerList = pl;
    }

    [PunRPC]
    public void nextTurn()
    {
        curTurn = (curTurn+1) % playerCount;

        for(int i=0; i<playerCount; i++)
        {
            PlayerControllerList[i].GetComponent<PhotonView>().RPC("CheckMyTurn", RpcTarget.All, i);
        }
    }

    public int GetCurTurn()
    {
        return curTurn;
    }

    public void GameStart()
    {
        for(int i=0; i<playerCount; i++)
        {
            PlayerControllerList[i].GetComponent<PhotonView>().RPC("CheckMyTurn", RpcTarget.All);
        }
    }
}
