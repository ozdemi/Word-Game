//using Microsoft.VisualBasic.CompilerServices;
using System.Security.AccessControl;
using System.Numerics;
//using System.Runtime.Intrinsics.Arm.Arm64;
using System.Security.Cryptography;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Debug = UnityEngine.Debug;
//using UnityEngine.Random;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using TMPro; 
using UnityEngine.UI;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        DontDestroyOnLoad(gameObject);
    }

    public override void OnConnectedToMaster(){
         Debug.Log("server hocam");
        PhotonNetwork.JoinLobby(); 
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobideyiz hocam");
    }

    public void RandomRoom(){
        PhotonNetwork.LoadLevel(1);
        PhotonNetwork.JoinRandomRoom();
    }

    public void CreateaRoom(){
        PhotonNetwork.LoadLevel(1);
        string roomname = Random.Range(0,987656).ToString();
        PhotonNetwork.JoinOrCreateRoom(roomname, new RoomOptions {MaxPlayers=2,IsOpen=true,IsVisible=true},TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        
        InvokeRepeating("checkInfo",0,1f);
        GameObject obj = PhotonNetwork.Instantiate("PlayerBomb",Vector3.zero,Quaternion.identity,0,null);
        obj.GetComponent<PhotonView>().Owner.NickName = PlayerPrefs.GetString("Username");

        if(PhotonNetwork.PlayerList.Length==1){
            obj.gameObject.tag="Player1Bomb";
        }else
        {
            obj.gameObject.tag="Player2Bomb";
        }
    }

    public override void OnLeftRoom(){
        

        
    }

    public override void OnLeftLobby(){
        

        
    }

    public void OnPlayerEnteredRoom(Player newPlayer){
        
        
    }

    public  void OnPlayerLeftRoom(Player otherPlayer){
        
        InvokeRepeating("checkInfo",0,1f);
    }

    public  void OnJoinRoomFailled(short returnCode, string message){
        
         
    }

    public  void OnJoinRandomFailled(short returnCode, string message){
        
         
    }

    public  void OnCreatedRoomFailled(short returnCode, string message){
        
        
    }

    void checkInfo(){

        if(PhotonNetwork.PlayerList.Length==2){
                GameObject.FindWithTag("PlayerWaiting").SetActive(false);
                GameObject.FindWithTag("Username1").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
                GameObject.FindWithTag("Username2").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[1].NickName;
                CancelInvoke("checkInfo");
        }else
        {
                GameObject.FindWithTag("PlayerWaiting").SetActive(true);
                GameObject.FindWithTag("Username1").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
                GameObject.FindWithTag("Username2").GetComponent<TextMeshProUGUI>().text = "....";
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
