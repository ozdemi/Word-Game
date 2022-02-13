
using System.Net.Mime;
//using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header ("Ball Setting")]
    public GameObject BallDepletioningEfect;
    public AudioSource DepletioningSound;

    [Header ("Other Boxes Setting")]
    public GameObject BoxDepletioningEfect;
    public AudioSource BoxDepletioningSound;

    [Header ("Player HealthBar Setting")]
    public Image player1_healthbar;
    float player1_health=100;
    public Image player2_healthbar;
    float player2_health=100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSoundandEfect(int choice,GameObject objTransform){
        switch (choice)
        {
            case 1:
            Instantiate(BallDepletioningEfect, objTransform.gameObject.transform.position, objTransform.gameObject.transform.rotation);
            DepletioningSound.Play();
            break;

            case 2:
            Instantiate(BoxDepletioningEfect, objTransform.gameObject.transform.position, objTransform.gameObject.transform.rotation);
            BoxDepletioningSound.Play();
            break;
        }
   
    }

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
