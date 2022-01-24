using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("StageMenu");
        Debug.Log("start");
    }

    public void OnClickQuitBtn()
    {
        Application.Quit();
        Debug.Log("end");
    }
}
