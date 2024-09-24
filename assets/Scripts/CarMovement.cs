using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class CarMovement : MonoBehaviour
{
    [SerializeField] private GameObject targetPos;
    [SerializeField] private Animation carAnim;
    [SerializeField] private GameObject[] positions = new GameObject[9];

    public static GameObject car;
    public static GameObject scoreTextGO;
    public static Text scoreText;

    [SerializeField] private float movementSpeed;

    [SerializeField] private Animation but1;
    [SerializeField] private Animation but2;
    [SerializeField] private Animation but3;
    [SerializeField] private Animation but4;

    private Vector3 lastPos;

    private bool isAbleToMove;

    [SerializeField] public static AudioSource carStart;
    [SerializeField] private AudioSource carDrive;
    [SerializeField] private AudioSource carCrash;    

    public static bool isCrashed = false;
    public static bool isDriving = false;

    public static float startSoundLenght = 3.5f;

    private void Start()
    {
        car = gameObject;
        targetPos = positions[4];
        lastPos = car.transform.position;

        but1 = GameObject.FindGameObjectWithTag("but1").GetComponent<Animation>();
        but2 = GameObject.FindGameObjectWithTag("but2").GetComponent<Animation>();
        but3 = GameObject.FindGameObjectWithTag("but3").GetComponent<Animation>();
        but4 = GameObject.FindGameObjectWithTag("but4").GetComponent<Animation>();
        carAnim = car.GetComponent<Animation>();

        carStart = GameObject.FindGameObjectWithTag("startSound").GetComponent<AudioSource>();
        carDrive = GameObject.FindGameObjectWithTag("driveSound").GetComponent<AudioSource>();
        carCrash = GameObject.FindGameObjectWithTag("crashSound").GetComponent<AudioSource>();
        MainMenuManager.controls.SetActive(false);
        car.SetActive(false);
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreTextGO = GameObject.FindGameObjectWithTag("ScoreText");
        scoreTextGO.SetActive(false);

    }
    private void Update()
    {
        if (!carStart.isPlaying && !carDrive.isPlaying && !isCrashed && isDriving)
            carDrive.Play();

        isAbleToMove = canMove();
        car.transform.position = Vector3.MoveTowards(transform.position, targetPos.transform.position, movementSpeed * Time.deltaTime);
    }

    public void moveHardLeft()
    {
        if(Time.time > startSoundLenght)
        {
        but1.Play("But1_Click");

            if (isAbleToMove)
            {
                movementSpeed = 0.5f;
            targetPos = positions[Array.IndexOf(positions, targetPos) - 2];
            carAnim.Play("Car_Move_Left");
            }
        }
    }
    
    public void moveLeft()
    {
        if (Time.time > startSoundLenght)
        {
            but2.Play("But2_Click");

            if (isAbleToMove)
            {
                movementSpeed = 0.25f;
                targetPos = positions[Array.IndexOf(positions, targetPos) - 1];
            carAnim.Play("Car_Move_Left_Bit");
            }
        }
    }
    
    public void moveRight()
    {
        if (Time.time > startSoundLenght)
        {
            but3.Play("But3_Click");

            if (isAbleToMove)
            {
                movementSpeed = 0.25f;
                targetPos = positions[Array.IndexOf(positions, targetPos) + 1];
            carAnim.Play("Car_Move_Right_Bit");
            }
        }
    }
    
    public void moveHardRight()
    {
        if (Time.time > startSoundLenght)
        {
            but4.Play("But4_Click");

            if (isAbleToMove)
            {
                movementSpeed = 0.5f;
                targetPos = positions[Array.IndexOf(positions, targetPos) + 2];
            carAnim.Play("Car_Move_Right");
            }
        }
    }

    private bool canMove()
    {
        Vector3 currentPos = car.transform.position;
        if (lastPos - currentPos == Vector3.zero)
        {
            return true;
        }
        else
        {
            lastPos = car.transform.position;
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDriving = false;
        isCrashed = true;
        carDrive.Stop();
        carCrash.Play();
        MainMenuManager.controls.SetActive(false);
        MainMenuManager.mainMenu.SetActive(true);
        MainMenuManager.transCanvas.Play("CircleTransition");
        car.SetActive(false);
        scoreTextGO.SetActive(false);
        Invoke("ReloadScene", 0.5f);   
    }

    private void ReloadScene()
    {
        isCrashed = false;
        car.SetActive(false);
        MainMenuManager.anim.Play("MainMenuFadeIn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
