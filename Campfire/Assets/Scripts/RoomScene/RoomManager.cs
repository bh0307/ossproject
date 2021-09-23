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
    void Start()
    {
        Debug.Log("test1111");
        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
            
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)//다른 플레이어가 방에 들어오면 작동
    {
        Debug.Log("test2222");
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
    

    public void ChangeScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
