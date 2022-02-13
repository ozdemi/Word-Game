using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class other_boxes : MonoBehaviour
{
    float health=100;
    public GameObject HealthCanvas;
    public Image healthbar;



    // Update is called once per frame
    void Update()
    {
        
    }

    public void darbeal(float force){
        health -= force;
        healthbar.fillAmount = health / 100 ;

        if (health <= 0 ){
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ExitCanvas());
        }
        
    
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