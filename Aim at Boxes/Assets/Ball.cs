using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviour
{
    float force;
    GameObject gameManager;
    GameObject player;
    PhotonView pw;
    AudioSource DepletioningSound;

    void Start()
    {
        force=20;
        gameManager=GameObject.FindWithTag("GameManager");
        pw = GetComponent<PhotonView>();
        DepletioningSound = GetComponent<AudioSource>();
        
    }
        [PunRPC]
        public void sendTag(string tag){
               
                player=GameObject.FindWithTag(tag);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OtherBoxes")){
                collision.gameObject.GetComponent<PhotonView>().RPC("darbeal",RpcTarget.All,force);
                
                player.GetComponent<Player>().PowerBarMoving();
                if(pw.IsMine){
                PhotonNetwork.Instantiate("Hit_SmokePuff_efect",transform.position,transform.rotation,0,null);        
                DepletioningSound.Play();
                PhotonNetwork.Destroy (gameObject);}
                
        }
        if (collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player2Bomb")){
                
                
                gameManager.GetComponent<PhotonView>().RPC("hitBoxes",RpcTarget.All,2,force);
                player.GetComponent<Player>().PowerBarMoving();
                if(pw.IsMine){
                PhotonNetwork.Instantiate("Hit_SmokePuff_efect",transform.position,transform.rotation,0,null);
                DepletioningSound.Play();
                PhotonNetwork.Destroy (gameObject);}
                
        }
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player1Bomb")){
                
                
                gameManager.GetComponent<PhotonView>().RPC("hitBoxes",RpcTarget.All,1,force);
                player.GetComponent<Player>().PowerBarMoving();
                if(pw.IsMine){
                PhotonNetwork.Instantiate("Hit_SmokePuff_efect",transform.position,transform.rotation,0,null);
                DepletioningSound.Play();
                PhotonNetwork.Destroy (gameObject);}
                
        }
        if (collision.gameObject.CompareTag("Ground")){
                
                
                player.GetComponent<Player>().PowerBarMoving();
                if(pw.IsMine){
                PhotonNetwork.Instantiate("Hit_SmokePuff_efect",transform.position,transform.rotation,0,null);
                DepletioningSound.Play();
                PhotonNetwork.Destroy (gameObject);}
                
        }
        
    }

}