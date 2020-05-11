using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHoverButton()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
