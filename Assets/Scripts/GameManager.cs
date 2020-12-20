using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;
    public float playedTime;
    public Text TimeText;
    public GameObject[] Stars;

    private bool _init =false;
    private int _matches =0;

    // Update is called once per frame
    void Update()
    {
        playedTime+=Time.deltaTime;
        TimeText.text="Time Played :"+Mathf.RoundToInt(playedTime).ToString();
        //intialize the cards if they were not initialized already
        if (!_init)
            initializeCards();
        // get input and start checking the cards
        if (Input.GetMouseButtonUp (0))
            checkCards();
        //Star Rating System
        if(Mathf.RoundToInt(playedTime)>60)//3 stars if spent less than 60 seconds completing the game
            Stars[2].SetActive(false);
        if(Mathf.RoundToInt(playedTime)>90)//2 stars if spent less than 90 seconds completing the game
            Stars[1].SetActive(false);
    }
    //Initializer for Cards
    void initializeCards(){
        //Nested Loop To Initialize each Twice 
        for(int id=0; id < 2; id++){
            for (int i=1; i<13; i++){//1-13 12 cards twice 24 cards in total
                bool test=false;
                int choice =0;
                //to choose a random card and intialize it
                while(!test){
                    choice=Random.Range(0,cards.Length);
                    test=!(cards [choice].GetComponent<Card>().initialized);
                }
                //give the card a value and set intialized to true
                cards[choice].GetComponent<Card>().cardValue=i;
                cards[choice].GetComponent<Card>().initialized= true;
            }
        }//setup the graphics for cards
        foreach(GameObject c in cards)
        c.GetComponent<Card>().setupGraphics ();
    //set init to true to indicate that the card is initialized
        if(!_init)
            _init=true;
    }
    //get the back of the card
    public Sprite getCardBack(){
        return cardBack;
    }
    //get the front of the card
    public Sprite getCardFace(int i){
        return cardFace[i-1];
    }
    //check cards
    void checkCards() {
        //create a list of cards with open face
        List<int> c= new List<int> ();
        //add the cardnumber into the list
        for(int i=0; i<cards.Length; i++){
            if(cards[i].GetComponent<Card>().state==1)
                    c.Add(i);
        }//if more than two cards are open compare them
        if (c.Count==2)
                cardComparison(c);
  
    }
    //Compare the two cards sent in the list
    void cardComparison(List<int> c){
        Card.donotFlip =true;//do not flip the cards for now
        int x=0;//to set state of cards
        if(cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue){//compare both cards
            x=2;
            _matches ++;//increase matches
            matchText.text= "Number of Matches: " +_matches;//update the score
            if(_matches==NewBehaviourScript._levelDifficulty)//check win or not
                SceneManager.LoadScene("GameOver");
        }
        for (int i=0; i<c.Count;i++){
            cards[c[i]].GetComponent<Card>().state=x;
            cards[c[i]].GetComponent<Card>().falseCheck ();
        }
    }
}
