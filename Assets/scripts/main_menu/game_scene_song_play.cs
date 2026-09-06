using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip song1;
    [SerializeField] private AudioClip song2;
    [SerializeField] private AudioClip song3;

    private const string MusicKey = "SelectedSong";

    private void Start()
    {
        int selectedSong = PlayerPrefs.GetInt(MusicKey, 0);

        switch (selectedSong)
        {
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
        if (song == null)
            return;

        audioSource.clip = song;
        audioSource.loop = true;
        audioSource.Play();
    }
}
