using UnityEngine;

public class AudioSet : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;
    private float backgroundFloat, soundEffectFloat;

    void Awake()
    {
        ContinueSettings();
    }

   private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectFloat;

        }
    }
}
