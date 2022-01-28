using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScript : MonoBehaviour
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
   public void OnClickStg1()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("GameMap1");
    }
    public void OnClickStg2()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("GameMap2");
    }
    public void OnClickStg3()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("GameMap3");
    }
    public void OnClickStg4()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("GameMap4");
    }
    public void OnCIickPrev()
    {
        clicksoundsource.Play();
        SceneManager.LoadScene("MainScene");
    }
}
