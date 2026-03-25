using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text FootSoundText;
    public TMP_Text Equipped;
    public TMP_Text Time;
    
    public int footSound = 0;
    public int maxFootSound;  //350
    public float treasureEquipped = 0;
    private PlayerController playerController;
    public int time=270;
    public int minutes=4;
    public int seconds = 3;
    public GameObject characterObject;
    public AudioSource mainThemeAudio;
    public AudioSource endAudio;
    public int tempTreasureSold = 0;
    public bool tempDidWin = false;
    // Start is called before the first frame update

    private static GameManager _instance = null;
        public static GameManager Instance
        {
            get { return _instance; }
        }

        void Awake()
        {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSources[0] = mainThemeAudio;
        audioSources[1] = endAudio;
        if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

        }
    
    void Start()
    {
        minutes = time / 60;
        seconds = time % 60;
        UpdateTimerText();
        StartCoroutine(UpdateTimer());
        

    }
   
    // Update is called once per frame
    void Update()
    {

        if (playerController != null)
        {
            // Update the footSound based on the player's currentMoveSpeed
            playerController.UpdateFootSound();
            // Update the FootSoundText with the updated footSound value

            FootSoundText.text = "Sound Level : " + ((footSound) / 100).ToString()+"/"+maxFootSound;
            Equipped.text = "Equipped : " + treasureEquipped.ToString()+"/2";

        }

    }

    IEnumerator UpdateTimer()
    {

        while (true)
        {
            time++;
            minutes = time / 60;
            seconds = time % 60;
            yield return new WaitForSeconds(1); // Wait for 1 second

            // Increase seconds
           
            // Check if seconds reached 60
            if (seconds >= 60)
            {
                // Reset seconds to 0
                seconds = 0;
                // Increase minutes
                minutes++;

                // Check if minutes reached 24 (representing hours)
                if (minutes >= 24)
                {
                    // Reset minutes to 0
                    minutes = 0;
                    // You can handle additional logic for day changes here
                }
            }

            // Update the timer text
            UpdateTimerText();
        }
        

    }
    void UpdateTimerText()
    {
        
        if(seconds>9)
        {
            Time.text = "0"+minutes.ToString() + ":" + seconds.ToString()+"/06:00";
        }
        else
        {
            Time.text = "0"+minutes.ToString() + ":0" + seconds.ToString()+"/06:00";
        }
    }
    
    public void PlayerFinder(PlayerController PC)
    {

        // Get the PlayerController component from the GameObject
        playerController = PC;
        
    }
    
}
