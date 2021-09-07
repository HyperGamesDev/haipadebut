using System;
using UnityEngine;
using UnityEngine.Audio;

public class VoiceActingManager : MonoBehaviour{
	public static VoiceActingManager instance;
	public AudioMixer audioMixer;
	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;

	void Awake(){
		if(instance!=null){Destroy(gameObject);}else{instance=this;DontDestroyOnLoad(gameObject);}

		foreach(Sound s in sounds){
			s.source=gameObject.AddComponent<AudioSource>();
			s.source.clip=s.clip;
			s.source.loop=s.loop;
			s.source.playOnAwake=false;

			s.source.outputAudioMixerGroup=mixerGroup;
		}
		if(sounds.Length>0)Play(0);
	}

	public void Play(int id){
		Sound s=sounds[id];
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
	public void PlayFromInstance(string sound){AudioManager.instance.Play(sound);}

	public void StopAll(){
		foreach(var s in sounds){if(s.source!=null)s.source.Stop();}
 	}
	public AudioClip Get(string sound){
		Sound s = Array.Find(sounds, item => item.name == sound);
		if(s == null){
			Debug.LogWarning("Sound: " + sound + " not found!");
			return null;
		}else{return s.clip;}
	}
	public AudioSource GetSource(string sound){
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null){
			Debug.LogWarning("Sound: " + sound + " not found!");
			return null;
		}else{return s.source;}
	}
}