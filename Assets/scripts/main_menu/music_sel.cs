using TMPro;
using UnityEngine;

public class music_sel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip song1;
    [SerializeField] private AudioClip song2;
    [SerializeField] private AudioClip song3;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(ChangeSong);
        ChangeSong(0);
    }

    private void ChangeSong(int index)
    {
        switch(index) {
            case 0:
                PlaySong(song1);
                break;
            case 1:
                PlaySong(song2);
                break;
            case 2:
                PlaySong(song3);
                break;
        }
    }

    private void PlaySong(AudioClip song)
    {
        AudioSource.clip = song;
        AudioSource.Play();
        PlayerPrefs.Save();
    }
}
