using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    GameObject controllerRight = GameObject.Find("Controller (right)");
    GameObject controllerLeft = GameObject.Find("Controller (left)");
    public SteamVR_TrackedObject myTrackedObjectRight, myTrackedObjectLeft;
    public SteamVR_Controller.Device rightController, leftController;
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    void Awake()
    {
        myTrackedObjectRight = controllerRight.GetComponent<SteamVR_TrackedObject>();
        myTrackedObjectLeft = controllerLeft.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rightController = SteamVR_Controller.Input((int)myTrackedObjectRight.index);
        leftController = SteamVR_Controller.Input((int)myTrackedObjectLeft.index);
        if (rightController.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (gamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }

        }
    }

    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene(4);
    }
}
