using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MusicScriptableObject[] albums;
    [SerializeField] private Image albumCover;
    [SerializeField] private Transform playlistParent;
    [SerializeField] private GameObject songButton;

    private MusicScriptableObject currentAlbum;
    private int albumIndex = 0;

    enum playlist
    {
        Ambrosia,
        America,
        BobbyCaldwel,
        ChristopherCross,
        Eagles,
        EarthWindAndFire,
        MichealJackson,
        TheBeachBoys,
        Toto
    }

    // Start is called before the first frame update
    void Start()
    {
        if (albums != null)
        {
            currentAlbum = albums[0];
            albumCover.sprite = currentAlbum.albumCover;
            SetMusicList();
        }
    }

    private void SetMusicList()
    {
        foreach (AudioClip song in currentAlbum.playlist)
        {
            songButton.GetComponentInChildren<TMP_Text>().text = song.name;
            songButton.GetComponent<AudioSource>().clip = song;
            Instantiate(songButton, playlistParent);
        }
    }
    private void ClearSongList()
    {
        for (int i = 0; i < playlistParent.transform.childCount; i++)
        {
            // Destroy the child GameObject
            Destroy(playlistParent.transform.GetChild(i).gameObject);
        }
    }

    private void SetAlbum()
    {
        currentAlbum = albums[albumIndex];
        albumCover.sprite = currentAlbum.albumCover;
    }

    public void NextAlbum()
    {
        if ((albumIndex + 1) < albums.Length)
        {
            albumIndex++;
        }
        SetAlbum();
        ClearSongList();
        SetMusicList();
    }

    public void PrevAlbum()
    {
        if ((albumIndex - 1) >= 0)
        {
            albumIndex--;
        }
        SetAlbum();
        ClearSongList();
        SetMusicList();
    }
}
