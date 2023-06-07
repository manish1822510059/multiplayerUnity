using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;



public class LobbyManager : MonoBehaviourPunCallbacks
{
   public InputField roomInputField;
   public GameObject lobbyPanel;
   public GameObject  roomPanel;

   public Text roomName;

   public RoomItem roomItemPrefab;
   List<RoomItem> roomItemsList = new List<RoomItem>();
   public Transform contentObject;

   public float timeBetweenUpdate = 1.5f;
   float nextUpdateTime;
   public PlayerItem playerItemPrefab;
   public Transform playerItemParent;

   public List<PlayerItem> playerItemsList = new List<PlayerItem>();




  private void Start() 
  { 
   PhotonNetwork.JoinLobby(); 
  }

  public void OnClickCreate(){
    if(roomInputField.text.Length >=1){
        PhotonNetwork.CreateRoom(roomInputField.text,new RoomOptions(){MaxPlayers = 3 ,BroadcastPropsChangeToAll = true});
    }
  }

public override void OnJoinedRoom(){
    lobbyPanel.SetActive(false);
    roomPanel.SetActive(true);
    roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    UpdatePlayerList();
}


public override void OnRoomListUpdate(List<RoomInfo> roomList){
    if(Time.time >= nextUpdateTime){
   UpdateRoomList(roomList);
   nextUpdateTime = Time.time + timeBetweenUpdate;
    }
}

   
   void UpdateRoomList(List<RoomInfo> list){
      foreach (RoomItem item in roomItemsList)
      {
        Destroy(item.gameObject);
      }
      roomItemsList.Clear();

      foreach (RoomInfo room in list)
      {
        RoomItem newRoom  = Instantiate(roomItemPrefab,contentObject);
        Debug.Log("item list");
        newRoom.SetRoomName(room.Name);
        roomItemsList.Add(newRoom);
      }
   }

   public void JoinedRoom(string roomName){
    PhotonNetwork.JoinRoom(roomName);
   }


   public void OnClickLeaveRoom(){
    PhotonNetwork.LeaveRoom();
   }

   public override void OnLeftRoom(){
     roomPanel.SetActive(false);
     lobbyPanel.SetActive(true);
   }

   public override void OnConnectedToMaster(){
       PhotonNetwork.JoinLobby();
   }
  
  void UpdatePlayerList(){
    foreach (PlayerItem item in playerItemsList)
    {
      Destroy(item.gameObject);
    }
    playerItemsList.Clear();
    if(PhotonNetwork.CurrentRoom == null){
      return;
    }
     foreach (KeyValuePair<int,Player> player in PhotonNetwork.CurrentRoom.Players){
          PlayerItem newPlayerItem = Instantiate(playerItemPrefab,playerItemParent);
          newPlayerItem.SetPlayerInfo(player.Value);
          if(player.Value == PhotonNetwork.LocalPlayer){
            newPlayerItem.ApplyLocalChanges();
          }
          playerItemsList.Add(newPlayerItem);
    }
   
  }
  public override void OnPlayerEnteredRoom(Player newPlayer){
    UpdatePlayerList();
  }

  public override void OnPlayerLeftRoom(Player otherPlayer){
     UpdatePlayerList();
  }
}
  


