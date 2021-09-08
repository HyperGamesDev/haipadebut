using System;
using UnityEngine;
using UnityEngine.Audio;

public class VoiceActingManager : MonoBehaviour{
	public static VoiceActingManager instance;
	public AudioMixer audioMixer;
	public AudioMixerGroup mixerGroup;
	public VA_Clip[] sounds;

	void Awake(){
		if(instance!=null){Destroy(gameObject);}else{instance=this;DontDestroyOnLoad(gameObject);}

		foreach(VA_Clip s in sounds){
			s.source=gameObject.AddComponent<AudioSource>();
			s.source.clip=s.clip;
			s.source.playOnAwake=false;

			s.source.outputAudioMixerGroup=mixerGroup;
		}
		if(sounds.Length>0&&UnityEngine.SceneManagement.SceneManager.GetActiveScene().name=="Game")Play(0);
	}

	public void Play(int id){
		VA_Clip s=sounds[id];
		if(s==null){
			Debug.LogWarning("Sound: "+id+" not found!");
			return;
		}

		//s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		//s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		//s.source.loop = s.loop;

		StopAll();
		if(s.source!=null)s.source.Play();
	}

	public void StopAll(){
		foreach(var s in sounds){if(s.source!=null)s.source.Stop();}
 	}
}
[System.Serializable]
public class VA_Clip {
	public AudioClip clip;
	[Range(0f, 1f)]
	public float volume = 1f;
	[Range(.1f, 3f)]
	public float pitch = 1f;

	[HideInInspector]
	public AudioSource source;
}