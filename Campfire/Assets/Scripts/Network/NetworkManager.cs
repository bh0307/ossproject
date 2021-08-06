using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region 접속 상태
    static bool isOnConnected = false;
    static bool isOnLobby = false;

    public static string GetStatus()
    {
        if (isOnLobby)
            return "isOnLobby";
        else if (isOnConnected)
            return "isOnConnected";
        else
            return "isDisConnected";
    }
    #endregion

    #region 서버 접속/종료
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        Debug.Log("Photon 서버 접속 완료");
        isOnConnected = true;
        JoinLobby();
    }

    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속 완료");
        isOnLobby = true;
    }

    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Photon 서버 접속 종료");
        isOnLobby = false;
        isOnConnected = false;
    }

    #endregion
}
