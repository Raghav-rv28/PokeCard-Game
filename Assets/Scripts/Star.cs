using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{   
    public float TimePlayed;
    public GameObject[] Stars;
    public Text TimeSpent;

    // Update is called once per frame
    void Update()
    {
        //Time System and Rating System
        TimePlayed+=Time.deltaTime;
        TimeSpent.text= "Time Spent:"+Mathf.RoundToInt(TimePlayed).ToString();
        //3rd Star Condition
        if(TimePlayed>60)
            Stars[2].SetActive(false);
        //2nd Star Condition
        if(TimePlayed>90)
            Stars[1].SetActive(false);
    }
    //Button/Trigger Control
    public void triggerMenuBehaviour(int i) {
        switch(i){
            default:
            //Quit Button
            case(0):
                Application.Quit();
            break;
            //Play Again Button
            case(1):
                SceneManager.LoadScene("Menu");
                break;
        }
    }
}
