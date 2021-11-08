using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using static GameManager;

public class InitManager : MonoBehaviour
{
    private int posX, posY;
    private int playerCount;
    public List<PlayerController> PlayerControllerList = new List<PlayerController>();

    public static InitManager IM;
    PhotonView PV;
    void Awake()
    {
        IM = this;
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        RandomPos();
        CreatePlayer();
        StartCoroutine(SetPlayersInfo());
    }

    void RandomPos()
    {
        while(true)
        {
            posX = Random.Range(2,6);
            posY = Random.Range(2,6);
            if(posX == 2 || posX == 5 || posY == 2 || posY ==5)
            {
                posX *= 2;
                posY *= 2;
                break;
            }
        }
    }

    void CreatePlayer() //플레이어 오브젝트 생성
    {
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PlayerObj"), new Vector3(posX, -0.5f, posY), Quaternion.identity);
    }

    IEnumerator SetPlayersInfo() //플레이어 순서 지정
    {
        yield return new WaitForSeconds(1f);
        //지연시간을 두지 않으면 네트워크 동기화 이전에 호출되어버림
        if(PhotonNetwork.IsMasterClient)
        {
            playerCount = PlayerControllerList.Count;

            for(int i=0; i<playerCount; i++)
            {
                PlayerControllerList[i].GetComponent<PhotonView>().RPC("SetTurn", RpcTarget.All, i);
            }
        }

        GM.SetValue(playerCount, PlayerControllerList);
        GM.GameStart();
    }
}
