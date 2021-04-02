using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	public AudioMixerGroup audioMixer;

    void Awake() {
        foreach(Sound s in sounds) {
        	s.source = gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;

        	s.source.volume = s.volume;
        	s.source.loop = s.loop;
        	s.source.outputAudioMixerGroup = audioMixer;
        }
    }

    public void Play(string name) {
    	AudioMixer mixer = Resources.Load("MasterMixer") as AudioMixer;
    	Sound s = Array.Find(sounds, sound => sound.name == name);
    	if(s == null) {
    		return;
    	}
    	s.source.Play();
    }

    public void Stop(string name) {
    	Sound s = Array.Find(sounds, sound => sound.name == name);
    	if(s == null) {
    		return;
    	}
    	s.source.Stop();
    }
}
