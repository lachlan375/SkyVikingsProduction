using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayAudio : MonoBehaviour {

        public AudioClip stixHit;
        public AudioClip drumBeat;

        public AudioSource audio;

        void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        void OnDrumStickHit()
        {
            audio.PlayOneShot(stixHit, 0.7F);
        }

    void OnDrumBeatHit()
        {
            audio.PlayOneShot(drumBeat, 0.7F);
        }

    }
