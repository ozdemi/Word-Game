using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float force;
    public GameObject BallDepletioningEfect;
    public AudioSource DepletioningSound;

    void Start()
    {
        force=20;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("OtherBoxes")){
                collision.gameObject.GetComponent<other_boxes>().darbeal(force);
                Instantiate(BallDepletioningEfect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                DepletioningSound.Play();
                Destroy (gameObject,.5f);
                //GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}