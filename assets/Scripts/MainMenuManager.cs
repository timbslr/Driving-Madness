using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] public static Animation anim;
    [SerializeField] public static Animation transCanvas;
    [SerializeField] public static GameObject controls;
    [SerializeField] private GameObject controlsETE;
    public static GameObject mainMenu;
    [SerializeField] private GameObject mainMenuETE;
    public static float startTime;

    private void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Animation>();
        //transCanvas = GameObject.FindGameObjectWithTag("transCanvas").GetComponent<Animation>();
        controls = GameObject.FindGameObjectWithTag("controls");
        mainMenu = GameObject.FindGameObjectWithTag("mainMenu");
        GameObject.FindGameObjectWithTag("StartRoad").GetComponent<RoadMovement>().enabled = false; 
    }
    public void StartGame()
    {
        anim.Play("MainMenuFadeOut");
        Invoke("activateControls", 1f);
        CarMovement.carStart.Play();
        CarMovement.isDriving = true;
        CarMovement.car.SetActive(true);  
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void activateControls()
    {
        controls.SetActive(true);
        mainMenu.SetActive(false);
        startTime = Time.time;
        CarMovement.scoreTextGO.SetActive(true);
        GameObject.FindGameObjectWithTag("StartRoad").GetComponent<RoadMovement>().enabled = true;

    }


}
