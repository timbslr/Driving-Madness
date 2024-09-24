using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private float timeSinceStart;
    private int timeSinceStartINT;
    private RoadMovement startRoad;
    [SerializeField] private Text hsText;
    void Awake()
    {
        startRoad = GameObject.FindGameObjectWithTag("StartRoad").GetComponent<RoadMovement>();
        hsText = GameObject.FindGameObjectWithTag("hsText").GetComponent<Text>();
        UpdateHighScore();
    }


    void Update()
    {
        if (CarMovement.isDriving && !CarMovement.isCrashed && startRoad.enabled)
        {
        timeSinceStart = Time.time - MainMenuManager.startTime;
        timeSinceStart *= 10;
        CarMovement.scoreText.text = ((int) timeSinceStart).ToString();
        }

        if(CarMovement.isCrashed)
        {
            if(timeSinceStart > GetHS())
            PlayerPrefs.SetFloat("highscore", timeSinceStart);

            UpdateHighScore();
        }
            
        
    }   

    private void OnEnable()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        timeSinceStartINT = (int) GetHS();
        hsText.text = timeSinceStartINT.ToString();
    }

    private float GetHS()
    {
        return PlayerPrefs.GetFloat("highscore", 0);
    }
}
