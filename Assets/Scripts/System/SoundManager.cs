using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSource = null;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ClipPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
