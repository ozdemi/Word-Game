using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float force;
    GameObject gameManager;

    void Start()
    {
        force=20;
        gameManager=GameObject.FindWithTag("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OtherBoxes")){
                collision.gameObject.GetComponent<other_boxes>().darbeal(force);
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                
                Destroy (gameObject);
                //GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Player2")){
                
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                gameManager.GetComponent<GameManager>().hitBoxes(2,force);
                Destroy (gameObject);
                //GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Player1")){
                
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                gameManager.GetComponent<GameManager>().hitBoxes(1,force);
                Destroy (gameObject);
                //GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}