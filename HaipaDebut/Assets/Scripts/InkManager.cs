using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkManager : MonoBehaviour {
    public static event Action<Story> OnCreateStory;

    void Awake(){
		// Remove the default message
		RemoveChildren();
		StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	void StartStory(){
		story=new Story(inkJSONAsset.text);
        if(OnCreateStory!=null)OnCreateStory(story);
		story.BindExternalFunction("state",(int i) =>{cm.ChangeState(i);});
		story.BindExternalFunction("bg",(int i) =>{bm.ChangeBg(i);});
		story.BindExternalFunction("va",(int i) =>{vam.Play(i);});
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView(){
		// Remove all the UI on screen
		RemoveChildren();
		vam.StopAll();
		
		// Read all the content until we can't continue any more
		while (story.canContinue) {
			// Continue gets the next line of the story
			string text=story.Continue ();
			// This removes any white space from the text.
			text=text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			Button choice=CreateChoiceView("Bye!");
			choice.onClick.AddListener(delegate{
				GameManager.instance.LoadPC();
			});
			/*Button choice2=CreateChoiceView("End of story.\nRestart?");
			choice2.onClick.AddListener(delegate{
				StartStory();
			});*/
			
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice){
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView(string text){
		TextMeshProUGUI storyText=Instantiate(textPrefab) as TextMeshProUGUI;
		storyText.text=text;
		List<string> tags=story.currentTags;
		if(tags.Count>0){if(tags[0]=="you"){storyText.GetComponent<TextMeshProUGUI>().color=new Color32(126, 231, 242, 255);}}
		storyText.transform.SetParent(textPanel.transform,false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView(string text){
		// Creates the button from a prefab
		Button choice=Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(buttonPanel.transform,false);
		
		// Gets the text from the button prefab
		TextMeshProUGUI choiceText=choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text=text;

		// Make the button expand to fit the text
		//HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		//layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren(){
		for(int i=textPanel.transform.childCount-1;i>=0;--i){Destroy(textPanel.transform.GetChild(i).gameObject);}
		for(int i=buttonPanel.transform.childCount-1;i>=0;--i){Destroy(buttonPanel.transform.GetChild(i).gameObject);}
	}

	[SerializeField]TextAsset inkJSONAsset=null;
	public Story story;

	[SerializeField]CharacterManager cm;
	[SerializeField]BackgroundManager bm;
	[SerializeField]VoiceActingManager vam;

	[SerializeField]GameObject textPanel=null;
	[SerializeField]GameObject buttonPanel=null;
	
	// UI Prefabs
	[SerializeField]TextMeshProUGUI textPrefab=null;
	[SerializeField]Button buttonPrefab=null;
}
