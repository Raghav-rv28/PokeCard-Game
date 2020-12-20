using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Number of Matches needed to be Made
        [SerializeField]
       public static int _levelDifficulty=0; 
    // Button Actions
    public void triggerMenuBehaviour(int i) {
        switch(i){
            default:
            //Easy Button
            case(0):
            _levelDifficulty=6;//6 matches
            SceneManager.LoadScene("Level");
            break;
            //Medium Button
            case(1):
            _levelDifficulty=8;//8 matches
            SceneManager.LoadScene("Level");
            break;
            //Hard Button
            case(2):
            _levelDifficulty=12;//12 matches
            SceneManager.LoadScene("Level");
            break;
            //Quit Button
            case(3):
                Application.Quit();
            break;
        }
    }
}
