using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    public static void PlayAudio(AudioSource source, AudioClip clip, bool loop = false)
    {
        if(!loop)
        {
            source.PlayOneShot(clip);
            return;
        }

        source.loop = loop;
        source.clip = clip;
        source.Play();
    }
}
