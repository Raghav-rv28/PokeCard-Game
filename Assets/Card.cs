using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   public static bool donotFlip =false;
    //state of the card 1 means closed and 0 means open
   [SerializeField]
   private int _state;
   //value of the card
   [SerializeField]
   private int _cardValue;
   [SerializeField]
   //card is intialized or not
   private bool _initialized =false;

   private Sprite _cardBack;//back of the card
   private Sprite _cardFace;//front of the card

   private GameObject _manager;//card manager

    //start the card as closed and find manager
   void Start(){
       _state=1;
       _manager = GameObject.FindGameObjectWithTag("Manager");
   }
    //Set their graphics
   public void setupGraphics(){
       _cardBack= _manager.GetComponent<GameManager>().getCardBack();
       _cardFace= _manager.GetComponent<GameManager>().getCardFace(_cardValue);
    //flip the cards
       flipCard();
   }
    //flip the cards
   public void flipCard(){
       //change the states
       if(_state==0)
       _state=1;
       else if(_state==1)
       _state=0;
       //change the graphic image of the card
       if(_state == 0 && !donotFlip)
        GetComponent<Image>().sprite =_cardBack;
       else if( _state ==1 && !donotFlip)
        GetComponent<Image>().sprite =_cardFace;

   }
    //getter and setter for cardvalue
   public int cardValue {
       get{ return _cardValue;}
       set{ _cardValue= value;}
   }
    //getter and setter for state
   public int state {
       get{return _state;}
       set{_state= value;}

   }
    //getter and setter for initialized
   public bool initialized {
        get{ return _initialized;}
        set { _initialized= value;}
   }
    //false check to intiate one second delay in flipping the cards
    public void falseCheck() {
        StartCoroutine (pause ());
    }
    //card graphic loader and wait for 1 second
    IEnumerator pause(){
        yield return new WaitForSeconds(1);
        if(_state==0)
            GetComponent<Image>().sprite =_cardBack;
        else if(_state==1)
            GetComponent<Image>().sprite =_cardFace;
        donotFlip=false;
}

}
