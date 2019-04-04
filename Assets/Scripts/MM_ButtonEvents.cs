using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM_ButtonEvents : MonoBehaviour
{
    public Button startButton, stopButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(BeginGame);
        stopButton.onClick.AddListener(StopGame);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
