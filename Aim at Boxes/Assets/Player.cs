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

    [Header ("Powerbar Setting")]
    public Image PowerBar;
    float powernum;
    bool theend=false;//It means the bar didn't come to the end yet.
    
    Coroutine powerLoop;

    PhotonView pw;

    void Start()
    {
        pw = GetComponent<PhotonView>();
       

       if(pw.IsMine){
           //GetComponent<PlayerBomb>().enabled = true;

           if(PhotonNetwork.IsMasterClient){
               transform.position = GameObject.FindWithTag("CreatingPoint1").transform.position;
           }
           else
           {
               transform.position = GameObject.FindWithTag("CreatingPoint2").transform.position;
           }
       }
       powerLoop = StartCoroutine(PowerBarStart());
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BallThrowingEfect, BallStartPoint.transform.position, BallStartPoint.transform.rotation);
            BallThrowingSound.Play();
            GameObject ballObj = Instantiate(ball, BallStartPoint.transform.position, BallStartPoint.transform.rotation);
            Rigidbody2D rg = ballObj.GetComponent<Rigidbody2D>();
            rg.AddForce(new Vector2(2f, 0f) * PowerBar.fillAmount * 15f, ForceMode2D.Impulse);
       
            StopCoroutine(powerLoop);
        }

    }

    public void PowerBarMoving()
    {
       powerLoop = StartCoroutine(PowerBarStart());
    }
}
