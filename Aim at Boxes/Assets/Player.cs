using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject BallStartPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ballObj = Instantiate(ball, BallStartPoint.transform.position, BallStartPoint.transform.rotation);
            Rigidbody2D rg = ballObj.GetComponent<Rigidbody2D>();
            rg.AddForce(new Vector2(2f, 0f) * 10f, ForceMode2D.Impulse);
        }
        
    }
}
