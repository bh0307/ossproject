using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using static GameManager;
using static MapManager;

public class InitManager : MonoBehaviour
{
    private int posX, posY;
    private Vector3 newPos;
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
        MM.SetMapPos();
        MM.SetGreenZone();
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
                newPos = MM.map_pos[posX, posY];
                break;
            }
        }
    }

    void CreatePlayer() //플레이어 오브젝트 생성
    {
        GM.mine = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PlayerObj"), newPos, Quaternion.identity);
        GM.myController = GM.mine.GetComponent<PlayerController>();
        GM.myController.curPosX = posX;
        GM.myController.curPosY = posY;
        GM.myController.InitTargetPlane();
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
                /* 마스터 클라이언트의 컨트롤러 기준으로 각 플레이어 차례 설정
                모든 클라이언트에서 각 플레이어의 차례가 동일하게 적용됨 */
            }

            GM.GetComponent<PhotonView>().RPC("SetPlayerCount", RpcTarget.All, playerCount);
        }

        GM.SetValue(PlayerControllerList);
        /*클라이언트 별로 컨트롤러 리스트의 순서가 다름
        대신 해당 리스트는 각 플레이어 컨트롤러를 적어도 한번씩 순회하기 위해 사용함
        따라서 리스트의 순서가 달라도 상관 없음*/

        GM.NewTurnStart();
        //플레이어 차례 시작
    }
}
