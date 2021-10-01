using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundPlayer : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] mainMenuClip;
    public AudioClip[] minionClip;
    public AudioClip[] bossClip;
    public AudioClip[] victoryClip;
    public AudioClip[] defeatClip;
    public string situation;
    bool isPlaying = false;

    public TMP_InputField inputText;

    void Start()
    {
        source = GetComponent<AudioSource>();
        //StartCoroutine(MainMenuMusic());
    }

    private void LateUpdate()
    {
        situation = inputText.text.ToString();
        switch (situation)
        {
            case "0": StartCoroutine(MainMenuMusic()); break;
            case "1": StartCoroutine(MinionMusic()); break;
            case "2": StartCoroutine(BossMusic()); break;
            case "3": StartCoroutine(VictoryMusic()); break;
            case "4": StartCoroutine(DefeatMusic()); break;
            default: break;
        }
    }

    

    IEnumerator MainMenuMusic()
    {
        do
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                source.PlayOneShot(mainMenuClip[0]);
            }
            if (situation != "0")
            {
                isPlaying = false;
                yield break;
            }
            yield return null;
        } while (isPlaying == true);
    }

    IEnumerator MinionMusic()
    {
        do
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                source.PlayOneShot(minionClip[0]);
            }
            if (situation != "0")
            {
                isPlaying = false;
                yield break;
            }
            yield return null;
        } while (isPlaying == true);
    }

    IEnumerator BossMusic()
    {
        do
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                source.PlayOneShot(bossClip[0]);
            }
            if (situation != "0")
            {
                isPlaying = false;
                yield break;
            }
            yield return null;
        } while (isPlaying == true);
    }

    IEnumerator VictoryMusic()
    {
        do
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                source.PlayOneShot(victoryClip[0]);
            }
            if (situation != "0")
            {
                isPlaying = false;
                yield break;
            }
            yield return null;
        } while (isPlaying == true);
    }

    IEnumerator DefeatMusic()
    {
        do
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                source.PlayOneShot(defeatClip[0]);
            }
            if (situation != "0")
            {
                isPlaying = false;
                yield break;
            }
            yield return null;
        } while (isPlaying == true);
    }
}