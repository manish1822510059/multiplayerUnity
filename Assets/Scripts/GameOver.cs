using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
      [SerializeField]
      private GameObject gameOverScreen;


    // Update is called once per frame
    public  void GameOverCheck(int curreentHp){
        if(curreentHp == 0){
            gameOverScreen.SetActive(true);
            Movement.PlayerMoving = false;
        }
    }
}
