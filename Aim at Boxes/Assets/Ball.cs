using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float force;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        force=20;
        gameManager=GameObject.FindWithTag("GameManager");
        player=GameObject.FindWithTag("Player1Bomb");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OtherBoxes")){
                collision.gameObject.GetComponent<other_boxes>().darbeal(force);
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                player.GetComponent<Player>().PowerBarMoving();
                Destroy (gameObject);
                
        }
        if (collision.gameObject.CompareTag("Player2Bomb") || collision.gameObject.CompareTag("Player2Bomb")){
                
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                gameManager.GetComponent<GameManager>().hitBoxes(2,force);
                player.GetComponent<Player>().PowerBarMoving();
                Destroy (gameObject);
                
        }
        if (collision.gameObject.CompareTag("Player1Bomb") || collision.gameObject.CompareTag("Player1Bomb")){
                
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                gameManager.GetComponent<GameManager>().hitBoxes(1,force);
                player.GetComponent<Player>().PowerBarMoving();
                Destroy (gameObject);
                
        }
        if (collision.gameObject.CompareTag("Ground")){
                
                gameManager.GetComponent<GameManager>().createSoundandEfect(1,collision.gameObject);
                player.GetComponent<Player>().PowerBarMoving();
                Destroy (gameObject);
                
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}