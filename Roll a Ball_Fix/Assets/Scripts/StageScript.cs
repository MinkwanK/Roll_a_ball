using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void OnClickStg1()
    {
        SceneManager.LoadScene("GameMap1");
    }
    public void OnCIickPrev()
    {
        SceneManager.LoadScene("MainScene");
    }
}
