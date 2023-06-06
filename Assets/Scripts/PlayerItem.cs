using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{

public Text playerName;

public void SetPlayerInfo(Player _player){
    playerName.text = _player.NickName;
}


}
