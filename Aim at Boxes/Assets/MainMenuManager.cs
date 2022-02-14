using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject FirstPanel;
    public GameObject SecondPanel;
    public InputField username;  
    public Text ExistUser;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Username")){
            FirstPanel.SetActive(true);
        }
        else
        {
            SecondPanel.SetActive(true);
            ExistUser.text=PlayerPrefs.GetString("Username");
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveUsername(){
        
        PlayerPrefs.SetString ("Username",username.text);
        FirstPanel.SetActive(false);
        SecondPanel.SetActive(true);
        ExistUser.text=PlayerPrefs.GetString("Username");
    }
}
