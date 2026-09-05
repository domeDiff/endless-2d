using UnityEngine;

public class music_sel : MonoBehaviour
{
    [SerializeField] private GameObject[] songs;


    public void song1()
    {
        songs[0].SetActive(true);
        songs[1].SetActive(false);
        songs[2].SetActive(false);
    }

    public void song2()
    {
        songs[0].SetActive(false);
        songs[1].SetActive(true);
        songs[2].SetActive(false);
    }

    public void song3()
    {
        songs[0].SetActive(false);
        songs[1].SetActive(false);
        songs[2].SetActive(true);
    }

}
