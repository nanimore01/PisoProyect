using UnityEngine;
using TMPro;
public class AudioDisplayer : MonoBehaviour
{
    [SerializeField] AudioClip[] music;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] TMP_Text _text;
    [SerializeField] Animation _animation;
    public void Start()
    {
        PlayASong(music[Random.Range(0, music.Length)]);
    }

    public void Update()
    {
        if (!_audioSource.isPlaying && _audioSource.time == 0f)
        {
            PlayASong(music[Random.Range(0, music.Length)]);
        }
    }

    public void PlayASong(AudioClip song)
    {
        _audioSource.clip = song;
        _audioSource.Play();
        DisplaySongName(song);
    }

    public void DisplaySongName(AudioClip song)
    {
        _text.text = song.name;
        _animation.Play();
    }
}
