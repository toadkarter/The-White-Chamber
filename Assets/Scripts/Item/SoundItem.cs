using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundItem : Item
{
    private AudioSource _audio = null;
    // Start is called before the first frame update
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void ToggleAudio()
    {
        if (_audio.isPlaying)
        {
            _audio.Stop();
        }
        else
        {
            _audio.Play();
        }
    }

    public override void Act()
    {
        ToggleAudio();
    }

    public override void AdvanceState(int id)
    {
        Debug.Log("Nothing happens");
    }
}
