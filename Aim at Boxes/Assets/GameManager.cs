
using System.Net.Mime;
//using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    



    [Header ("Player HealthBar Setting")]
    public Image player1_healthbar;
    float player1_health=100;
    public Image player2_healthbar;
    float player2_health=100;
    PhotonView pw;
   

    private void Start() {
         pw = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void hitBoxes(int choice,float forceValue){
        switch (choice)
        {
            case 1:
            player1_health -= forceValue;
            player1_healthbar.fillAmount = player1_health / 100 ;
            break;

            case 2:
            player2_health -= forceValue;
            player2_healthbar.fillAmount = player2_health / 100 ;
            break;
        }
   
    }

}
