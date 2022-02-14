using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class other_boxes : MonoBehaviour
{
    float health=100;
    public GameObject HealthCanvas;
    public Image healthbar;

    GameObject gameManager;
    PhotonView pw;
    AudioSource BoxDepletioningSound;
    void Start(){
       gameManager=GameObject.FindWithTag("GameManager"); 
       pw = GetComponent<PhotonView>();
       BoxDepletioningSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void darbeal(float force){

        if(pw.IsMine){
        health -= force;
        healthbar.fillAmount = health / 100 ;

        if (health <= 0 ){
           //gameManager.GetComponent<GameManager>().createSoundandEfect(2,gameObject);
            
                PhotonNetwork.Instantiate("Box_Broken_efect",transform.position,transform.rotation,0,null);
                BoxDepletioningSound.Play();
                PhotonNetwork.Destroy (gameObject);
        }
        else
        {
            StartCoroutine(ExitCanvas());
        }}
        
    
    }

    IEnumerator ExitCanvas()
    {
        if(!HealthCanvas.activeInHierarchy){
        HealthCanvas.SetActive(true);
        yield return new WaitForSeconds(2);
        HealthCanvas.SetActive(false);
        }
    }
}