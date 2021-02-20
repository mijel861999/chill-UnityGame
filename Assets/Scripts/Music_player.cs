using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_player : MonoBehaviour
{

    public List<AudioClip> allSongs = new List<AudioClip>();
    public AudioSource audioPlayer;
    public int songPlaying = -1;
    public Text songLabel;

    public static Music_player sharedInstance;
    // Start is called before the first frame update
    void Start()
    {
        if (sharedInstance == null) {
            sharedInstance = this;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")) {
            if (songPlaying == allSongs.Count-1)
            {
                songPlaying = 0;
                audioPlayer.clip = allSongs[songPlaying];
                songLabel.text = allSongs[songPlaying].ToString();
                audioPlayer.Play();
            }
            else {
                songPlaying++;
                audioPlayer.clip = allSongs[songPlaying];
                songLabel.text = allSongs[songPlaying].ToString();
                audioPlayer.Play();
            }
        }              
    }
}
