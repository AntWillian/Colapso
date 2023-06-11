using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource audioMusicaDeFundo;

    public AudioSource audioSourceSFX;
    public AudioClip[] musicas;

    // Start is called before the first frame update
    void Start()
    {
        AudioClip musicaDeFundoFase = musicas[0];
        audioMusicaDeFundo.clip = musicaDeFundoFase;
        audioMusicaDeFundo.loop = true;
        audioMusicaDeFundo.Play();
    }

    public void ToqueSFX(AudioClip clip){

        audioSourceSFX.PlayOneShot(clip);
        audioSourceSFX.clip = clip;
        audioSourceSFX.Play();
    }
}
