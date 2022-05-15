using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMusicManager : MonoBehaviour
{
    private AudioSource player;

    private void Awake()
    {
        player = GetComponent<AudioSource>();
        MessageBroker.Instance.OnTryPlayDialogueSoundEffect += TryPlaySoundEffect;
    }

    private void TryPlaySoundEffect(AudioClip soundEffect)
    {
        if (soundEffect != null)
        {
            player.clip = soundEffect;
            player.Play();
        }
    }
}
