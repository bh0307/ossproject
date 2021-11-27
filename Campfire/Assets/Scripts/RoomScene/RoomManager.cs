using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.IO;//Path사용위에 사용
using System.Linq;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject gameStartBtn;
    void Start()
    {
        Debug.Log("test1111");
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        gameStartBtn.SetActive(PhotonNetwork.IsMasterClient);

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)//다른 플레이어가 방에 들어오면 동작
    {
        Debug.Log("test2222");
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
    
    public void LeaveRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    
    public void GameStart()
    {
        //if(PhotonNetwork.PlayerList.Count() == 4)
        PhotonNetwork.LoadLevel(5);   //진 게임씬
        //PhotonNetwork.LoadLevel(4);     //개발용 게임씬
    }
}
