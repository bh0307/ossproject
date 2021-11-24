using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    PhotonView PV;

    void Awake()
    {
        UM=this;
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
