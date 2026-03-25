using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    PlayerController PC;
    public TMP_Text endTime; //end

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "WonScene")
            endTime.text = GameManager.Instance.minutes + ":" + GameManager.Instance.seconds;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(LoadSceneAfterDelay("House1", 0.0f));

    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void reStartGame()
    {
        GameManager.Instance.treasureEquipped = 0;
        GameManager.Instance.time = 240;
        GameManager.Instance.tempTreasureSold = 0;
        GameManager.Instance.tempDidWin = false;
        GameManager.Instance.footSound = 0;
        GameManager.Instance.endAudio.Stop();
        GameManager.Instance.mainThemeAudio.Play();
        StartCoroutine(LoadSceneAfterDelay("House1", 0.0f));
    }
    public void linkedin(){
        Application.OpenURL("https://www.linkedin.com/in/enes-arda-g%C3%BCneri-478b542b0/");
        Application.OpenURL("https://www.linkedin.com/in/emre-u%C3%A7maz-449533296/");
    }

     
}
