using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager instance;
    void Awake(){
        if(instance!=null){Destroy(gameObject);}else{instance=this;DontDestroyOnLoad(gameObject);}
    }
    void Update(){
        
    }


    public void LoadMenu(){SceneManager.LoadScene("Menu");}
    public void LoadGame(){SceneManager.LoadScene("Game");}
    public void LoadPC(){SceneManager.LoadScene("PC");}
}
