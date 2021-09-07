using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject secondPanel;
    [SerializeField] GameObject bg2;
    [SerializeField] GameObject hand;
    [SerializeField] TMPro.TextMeshProUGUI text;
    void Start(){
        bg2.GetComponent<BackgroundManager>().ChangeBg(0);
        mainMenuPanel.SetActive(true);
        secondPanel.SetActive(false);
        bg2.SetActive(false);
        hand.SetActive(false);
        text.transform.parent.gameObject.SetActive(false);
    }
    public void StartButton(){StartCoroutine(StartButtonI());}
    IEnumerator StartButtonI(){
        mainMenuPanel.SetActive(false);
        secondPanel.SetActive(true);
        bg2.SetActive(true);
        hand.SetActive(true);
        text.transform.parent.gameObject.SetActive(true);
        text.text="Ah yes, finally my favorite ramune";
        yield return new WaitForSeconds(2f);
        text.text="Time to head back!";
        hand.SetActive(false);
        bg2.GetComponent<BackgroundManager>().ChangeBg(1);
        yield return new WaitForSeconds(2f);
        GameManager.instance.LoadGame();
    }
    public void QuitButton(){Application.Quit();}
}
