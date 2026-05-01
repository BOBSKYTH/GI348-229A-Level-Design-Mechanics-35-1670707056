using UnityEngine;
using System.Collections;

public class SimpleMusic : MonoBehaviour
{
    
    AudioSource audioSource;

    float[] notes = {
        261.63f, 329.63f, 392.00f, 329.63f,
        293.66f, 349.23f, 440.00f, 349.23f,

        261.63f, 329.63f, 392.00f, 329.63f,
        392.00f, 440.00f, 392.00f, 0f
    };

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayMusic());
        audioSource.volume = 0.03f; // 0 = เงียบ, 1 = ดังสุด
    }

    IEnumerator PlayMusic()
    {
        while (true) // 🔁 loop
        {
            foreach (float note in notes)
            {
                if (note > 0)
                {
                    audioSource.clip = CreateTone(note, 0.25f);
                    audioSource.Play();
                }

                yield return new WaitForSeconds(0.25f);
            }
        }
    }

    AudioClip CreateTone(float freq, float duration)
    {
        int sampleRate = 44100;
        int samples = (int)(sampleRate * duration);
        AudioClip clip = AudioClip.Create("tone", samples, 1, sampleRate, false);

        float[] data = new float[samples];

        for (int i = 0; i < samples; i++)
        {
            data[i] = Mathf.Sin(2 * Mathf.PI * freq * i / sampleRate);
        }

        clip.SetData(data, 0);
        return clip;
    }
}