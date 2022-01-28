using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource clicksoundsource;
    public AudioClip clicksound;
    // Start is called before the first frame update
    void Start()
    {

        clicksoundsource = gameObject.AddComponent<AudioSource>();
        clicksoundsource.clip = clicksound;
        clicksoundsource.loop = false;
    }

    // Update is called once per frame
    public void OnClickStartBtn()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("StageMenu");
        Debug.Log("start");
    }

    public void OnClickQuitBtn()
    {
        clicksoundsource.Play();
        Application.Quit();
        Debug.Log("end");
    }
}
