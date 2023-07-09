using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource ballHitAudioSource;
    public AudioSource mainThemeAudioSource;
    public List<AudioClipDefinition> audioClipList;
    public float ballHitPitchScale = 0.1f;
    public int soundVariety = 8;
    private float generalAudioVolume = 0.5f;
    private AudioSource audioSource;
    private float originalPitch;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPitch = audioSource.pitch;
        SetAllAudioSourcesToVolume();
    }

    public void PlaySound(ListedAudioClip audioClipToUseIdentifier)
    {
        AudioClipDefinition audioClipDef = GetAudioClipDefinition(audioClipToUseIdentifier);
        audioSource.PlayOneShot(audioClipDef.audioClip);
    }

    public void PlayCollideWithBallSound()
    {
        int soundVarietyHalf = Mathf.FloorToInt(soundVariety/2);
        float pitchMultiplier = (float)Random.Range(-soundVarietyHalf,soundVarietyHalf);
        ballHitAudioSource.pitch = originalPitch + ballHitPitchScale * pitchMultiplier;
        AudioClip ballAudio = GetAudioClipDefinition(ListedAudioClip.PaddleBallCollision).audioClip;
        ballHitAudioSource.PlayOneShot(ballAudio);
    
    }

    public void PlayMainTheme()
    {
        mainThemeAudioSource.Play();
    }

    public void StopMainTheme()
    {
        mainThemeAudioSource.Stop();
    }

    private AudioClipDefinition GetAudioClipDefinition(ListedAudioClip audioClipToUseIdentifier)
    {
        return audioClipList.Find((audioClipDefinition) => audioClipDefinition.identifier == audioClipToUseIdentifier);
    }

    private void SetAllAudioSourcesToVolume()
    {
        audioSource.volume = generalAudioVolume;
        ballHitAudioSource.volume = generalAudioVolume;
        mainThemeAudioSource.volume = generalAudioVolume;
    }

}

[System.Serializable]
public struct AudioClipDefinition {
    public ListedAudioClip identifier;
    public AudioClip audioClip;
}

public enum ListedAudioClip {
    PaddleBallCollision
}