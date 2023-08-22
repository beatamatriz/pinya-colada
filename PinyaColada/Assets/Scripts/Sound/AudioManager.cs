using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour {
    public static AudioManager ins;

    public List<Sound> sounds;

    private void Awake() {
        if (ins == null) {
            ins = this;
        }

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(int index) {
        sounds[index].source.Play();
    }
}