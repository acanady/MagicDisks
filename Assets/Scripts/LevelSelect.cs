using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    GameObject[] pauseObjects;
    private SteamVR_TrackedController controller;
    private PrimitiveType currPrimitiveType = PrimitiveType.Sphere;

    private void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.PadClicked += HandlePadClicked;
    }

    private void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
        controller.PadClicked -= HandlePadClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        SpawnCurrentPrimitiveAtController();
    }

    private void SpawnCurrentPrimitiveAtController()
    {
        var spawnedPrimitive = GameObject.CreatePrimitive(currPrimitiveType);
        spawnedPrimitive.transform.position = transform.position;
        spawnedPrimitive.transform.rotation = transform.rotation;

        spawnedPrimitive.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        if (currPrimitiveType == PrimitiveType.Plane)
        {
            spawnedPrimitive.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        if (e.padY < 0)
        {
            SelectPreviousPrimitive();
        }
        else
        {
            SelectNextPrimitive();
        }
    }

    private void SelectNextPrimitive()
    {
        currPrimitiveType++;
        if (currPrimitiveType > PrimitiveType.Quad)
        {
            currPrimitiveType = PrimitiveType.Sphere;
        }
    }

    private void SelectPreviousPrimitive()
    {
        currPrimitiveType--;
        if (currPrimitiveType < PrimitiveType.Sphere)
        {
            currPrimitiveType = PrimitiveType.Quad;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
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
