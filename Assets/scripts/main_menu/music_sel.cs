using TMPro;
using UnityEngine;

public class music_sel : MonoBehaviour
{
    public static music_sel instance;

    [Header("Dropdown")]
    [SerializeField] private TMP_Dropdown dropdown;

    [Header("Music")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip song1;
    [SerializeField] private AudioClip song2;
    [SerializeField] private AudioClip song3;

    private const string MusicKey = "SelectedSong";

    private void Awake()
    {
        // Make sure only one music manager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Keep this object and music when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Get saved song
        int savedSong = PlayerPrefs.GetInt(MusicKey, 0);

        // Set dropdown to saved song
        dropdown.SetValueWithoutNotify(savedSong);

        // Listen for dropdown changes
        dropdown.onValueChanged.AddListener(ChangeSong);

        // Play saved song
        PlaySong(savedSong);
    }

    public void ChangeSong(int index)
    {
        // Save selected song
        PlayerPrefs.SetInt(MusicKey, index);
        PlayerPrefs.Save();

        // Play selected song
        PlaySong(index);
    }

    private void PlaySong(int index)
    {
        AudioClip selectedSong = null;

        switch (index)
        {
            case 0:
                selectedSong = song1;
                break;

            case 1:
                selectedSong = song2;
                break;

            case 2:
                selectedSong = song3;
                break;
        }

        if (selectedSong == null)
        {
            Debug.LogWarning("Music clip is missing!");
            return;
        }

        // Don't restart if the same song is already playing
        if (audioSource.clip == selectedSong && audioSource.isPlaying)
            return;

        audioSource.clip = selectedSong;
        audioSource.loop = true;
        audioSource.Play();
    }
}
