//using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Ball Setting")]
    public GameObject BallDepletioningEfect;
    public AudioSource DepletioningSound;

    [Header ("Other Boxes Setting")]
    public GameObject BoxDepletioningEfect;
    public AudioSource BoxDepletioningSound;
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

}
