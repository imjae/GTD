using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReturnMenu()
    {
        SceneManager.LoadScene("GTD_start");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
