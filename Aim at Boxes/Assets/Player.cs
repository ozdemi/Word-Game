//using System.Threading.Tasks.Dataflow;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject BallStartPoint;
    public ParticleSystem BallThrowingEfect;
    public AudioSource BallThrowingSound;
    float throwingspin;

    [Header ("Powerbar Setting")]
     Image PowerBar;
    float powernum;
    bool theend=false;//It means the bar didn't come to the end yet.
    
    Coroutine powerLoop;

    PhotonView pw;

    void Start()
    {
        pw = GetComponent<PhotonView>();
       

       if(pw.IsMine){
           
           PowerBar = GameObject.FindWithTag("Powerbar").GetComponent<Image>();

           if(PhotonNetwork.IsMasterClient){
              // gameObject.tag="PlayerBomb1";
               transform.position = GameObject.FindWithTag("CreatingPoint1").transform.position;
               transform.rotation = GameObject.FindWithTag("CreatingPoint1").transform.rotation;
               throwingspin = 2f;
           }
           else
           {
               //gameObject.tag="PlayerBomb2";
               transform.position = GameObject.FindWithTag("CreatingPoint2").transform.position;
               transform.rotation = GameObject.FindWithTag("CreatingPoint2").transform.rotation;
                throwingspin = -2f;
           }
       }
       InvokeRepeating("startGameCheck",0,.5f);
    }

    public void startGameCheck(){
        
        if(PhotonNetwork.PlayerList.Length==2){
           if(pw.IsMine){
               
               powerLoop = StartCoroutine(PowerBarStart());
            CancelInvoke("startGameCheck");
               
           }else
           {
               StopAllCoroutines();
           }
        
            
        }
        
    }

    IEnumerator PowerBarStart(){

        PowerBar.fillAmount=0;
        theend=false;

        while(true){
            if(PowerBar.fillAmount<1 && !theend){
                powernum = 0.01f;
                PowerBar.fillAmount += powernum;
                yield return new WaitForSeconds(0.0002f * Time.deltaTime);
            }else
            {
                theend=true;
                powernum = 0.01f;
                PowerBar.fillAmount -= powernum;
                yield return new WaitForSeconds(0.0002f * Time.deltaTime);
                   
                    if(PowerBar.fillAmount == 0){
                        theend = false;
                    }
            
            }
        }
    }

   
    void Update()
    {
        if(pw.IsMine){
            if(Input.GetKeyDown(KeyCode.Space))
            {
            
            PhotonNetwork.Instantiate("Fire_Explosion_efect",BallStartPoint.transform.position,BallStartPoint.transform.rotation,0,null);
            BallThrowingSound.Play();
            GameObject ballObj = PhotonNetwork.Instantiate("Ball",BallStartPoint.transform.position,BallStartPoint.transform.rotation,0,null);
            ballObj.GetComponent<PhotonView>().RPC("sendTag",RpcTarget.All,gameObject.tag);
            Rigidbody2D rg = ballObj.GetComponent<Rigidbody2D>();
            rg.AddForce(new Vector2(throwingspin, 0f) * PowerBar.fillAmount * 15f, ForceMode2D.Impulse);
            StopCoroutine(powerLoop);
            }
        }


    }

    public void PowerBarMoving()
    {
       powerLoop = StartCoroutine(PowerBarStart());
    }
}
