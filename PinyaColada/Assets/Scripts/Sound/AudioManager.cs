using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour {
    public List<Sound> sounds;
    private void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        foreach (Sound s in sounds) {
            if (s.name == name) {
                s.source.Play();
                // PlayerElections.ins.aM.Play("")
            }
        }
    }
}