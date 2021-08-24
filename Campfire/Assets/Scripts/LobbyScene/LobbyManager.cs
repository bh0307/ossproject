using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    #region 변수

    [Header("Network")]
    [SerializeField] private NetworkManager networkManager;

    [Header("Panel")]
    public GameObject lobbyPanel;
    public GameObject matchingPanel;

    [Header("Button")]
    public Button[] roomBtn;
    public Button prev, next, back;
    
    [Header("ETC")]
    public Text StatusText;
    int cur = 0, maxpage;
    private List<RoomInfo> current_roomList = new List<RoomInfo>();

    #endregion

    #region start,update

    void Start()
    {
        //networkManager.Connect();
        matchingPanel.SetActive(false);
    }
    void Update()
    {
        StatusText.text = networkManager.Status();
    }

    #endregion

    #region panel
    public void PanelChange()
    {
        lobbyPanel.SetActive(!lobbyPanel.activeSelf);
        matchingPanel.SetActive(!lobbyPanel.activeSelf); //항상 lobbyPanel과 다른상태를 유지한다.
    }
    #endregion

    #region RoomList Update
    public override void OnRoomListUpdate(List<RoomInfo> changed_roomList)  //이전과 비교해 바뀐부분만 changed_roomList로 만들어진다.
    {
        Debug.Log("RoomListUpDate");
        CurRoomListUpdate(changed_roomList);
        ButtonUpdate(current_roomList);
    }

    public void CurRoomListUpdate(List<RoomInfo> changed_roomList) //changed_roomList를 바탕으로 current_roomList를 Update
    {
        for (int i = 0; i < changed_roomList.Count; i++)
        {
            if (changed_roomList[i].RemovedFromList)
                current_roomList.RemoveAt(current_roomList.IndexOf(changed_roomList[i]));   //사라진 방 제거
            else
            {
                if (current_roomList.Contains(changed_roomList[i]))
                    current_roomList[current_roomList.IndexOf(changed_roomList[i])] = changed_roomList[i]; //변경된 방 업데이트
                else
                    current_roomList.Add(changed_roomList[i]); //생긴 방 추가
            }
        }
        for (int i = 0; i < current_roomList.Count; i++)
            print("Debug : " + i.ToString() + " " + current_roomList[i].Name + " " + current_roomList[i].PlayerCount.ToString());
    }

    public void ButtonUpdate(List<RoomInfo> current_roomList)  //current_roomList를 바탕으로 Button Update
    {
        for (int i = 0; i < roomBtn.Length; i++)
        {
            if (cur*4+i >= current_roomList.Count)
            {
                roomBtn[i].interactable = false;
                roomBtn[i].transform.GetChild(0).GetComponent<Text>().text = "";
                roomBtn[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
            else
            {
                roomBtn[i].interactable = true;
                roomBtn[i].transform.GetChild(0).GetComponent<Text>().text = current_roomList[cur * 4 + i].Name;
                roomBtn[i].transform.GetChild(1).GetComponent<Text>().text = current_roomList[cur * 4 + i].PlayerCount.ToString() + "/4";
            }
        }
    }
    #endregion

    #region JoinRoom
    public void JoinRoom(int i)
    {
        string RoomName = roomBtn[i].transform.GetChild(0).GetComponent<Text>().text;
        networkManager.JoinRoom(RoomName);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("방 접속 완료");
        SceneManager.LoadScene("RoomScene");
    }
    #endregion
}
