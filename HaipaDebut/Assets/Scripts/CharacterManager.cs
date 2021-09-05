using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour{
    public Sprite[] sprites;
    //public Sprite[] emotionSprites=new Sprite[6];
    Image sprRend;
    /*public enum CharacterEmotion{
        neutral,happy,sad,angry,surprised,lewd
    }CharacterEmotion myState;*/
    void Start(){
        sprRend=GetComponent<Image>();
    }
    public void ChangeState(int i){//string emotionName){
        sprRend.sprite=sprites[i];
        //StartCoroutine(emotionName+"State");
    }
    /*IEnumerator NeutralState(){sprRend.sprite=emotionSprites[0];/*myState=(CharacterEmotion)0;*//*yield return null;}
    IEnumerator HappyState(){sprRend.sprite=emotionSprites[1];yield return null;}
    IEnumerator SadState(){sprRend.sprite=emotionSprites[2];yield return null;}
    IEnumerator AngryState(){sprRend.sprite=emotionSprites[3];yield return null;}
    IEnumerator SurprisedState(){sprRend.sprite=emotionSprites[4];yield return null;}
    IEnumerator LewdState(){sprRend.sprite=emotionSprites[5];yield return null;}*/
}
