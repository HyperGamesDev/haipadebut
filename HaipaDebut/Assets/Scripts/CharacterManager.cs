using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour{
    public Sprite[] sprites;
    Image sprRend;
    void Awake(){sprRend=GetComponent<Image>();}
    public void ChangeState(int i){if(sprRend!=null&&sprites[i]!=null)sprRend.sprite=sprites[i];}
}
