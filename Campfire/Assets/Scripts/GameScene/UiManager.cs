using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject myTurnStartPanel;
    [SerializeField]
    GameObject myTurnMovePanel;
    [SerializeField]
    GameObject myTurnActionPanel;
    [SerializeField]
    GameObject othersTurnPanel;

    public static UiManager UM;
    public float LImitTime;
    public Text text_Timer;
    PhotonView PV;

    void Awake()
    {
        UM=this;
        PV = GetComponent<PhotonView>();
    }
     void Update()
    {
        LImitTime -= Time.deltaTime;
        text_Timer.text = "제한시간 : " + Mathf.Round(LImitTime);
        if(LImitTime <= 1)
        {
            GameManager.GM.RPC_NewTurnStart();
            LImitTime = 10f;
        }
    }

    public void MyTurnStart()
    {
        myTurnStartPanel.SetActive(true);
        myTurnMovePanel.SetActive(false);
        myTurnActionPanel.SetActive(false);
        othersTurnPanel.SetActive(false);
    }

    public void MyTurnMove()
    {
        myTurnStartPanel.SetActive(false);
        myTurnMovePanel.SetActive(true);
        myTurnActionPanel.SetActive(false);
        othersTurnPanel.SetActive(false);
        GameManager.GM.myController.Bulddeok();
    }

    public void MyTurnAction()
    {
        myTurnStartPanel.SetActive(false);
        myTurnMovePanel.SetActive(false);
        myTurnActionPanel.SetActive(true);
        othersTurnPanel.SetActive(false);
    }

    public void OthersTurn()
    {
        myTurnStartPanel.SetActive(false);
        myTurnMovePanel.SetActive(false);
        myTurnActionPanel.SetActive(false);
        othersTurnPanel.SetActive(true);
    }
}
