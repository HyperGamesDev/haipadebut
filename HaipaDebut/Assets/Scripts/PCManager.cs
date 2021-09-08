using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour{
    [SerializeField] GameObject[] panels;
    [SerializeField] int currentPanel;
    IEnumerator Start(){
        AudioManager.instance.Play("keyboardTyping");
        TurnOffAllPanels();
        yield return new WaitForSeconds(3.55f);
        TurnOnPanel(0);
    }
    
    void TurnOffAllPanels(){foreach(GameObject go in panels){go.SetActive(false);}}
    public void TurnOnPanel(int i){panels[i].SetActive(true);currentPanel=i;}
    public void TurnOnNextPanel(){if(currentPanel<panels.Length){TurnOnPanel(currentPanel+1);}}
    public void TurnOnPrevPanel(){if(currentPanel>0){TurnOnPanel(currentPanel-1);}}
}
