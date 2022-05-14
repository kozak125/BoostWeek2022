using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMusicManager : MonoBehaviour
{
    private MusicGroup previousMusicGroup;
    private AudioSource player;

    private void Awake()
    {
        player = GetComponent<AudioSource>();
    }

    public void TryPlayNewAudio(MusicGroup newMusicGroup, AudioClip audio)
    {
        if (newMusicGroup == null || audio == null)
        {
            return;
        }    

        if (previousMusicGroup == null || previousMusicGroup.MusicGroupName != newMusicGroup.MusicGroupName)
        {
            player.clip = audio;
            player.Play();

            previousMusicGroup = newMusicGroup;
        }
    }
}
