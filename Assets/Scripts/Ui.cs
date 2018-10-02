//NYAN NYAN NYAN
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.VersionEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public GameObject HealthText; //assign heath to a text form
    public GameObject PointsText; //assign points to a text form
    public GameObject VersionText;//version text ui
    public GameObject TutorialText; //tutorial text ui
    public GameObject ChangeLogText; //changelog text ui
    public GameObject PauseUI; //pause ui part
    public GameObject MainPlayerUI; //main menu ui part
    public GameObject OptionsUI; //options ui part

    private bool isPaused = false; //paused or not 
    private GameObject Player; //link to player
    private Player PlayerScript;  //link to player script

    // Use this for initialization
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        HealthText = GameObject.Find("Health Text");
        PointsText = GameObject.Find("Points Text");
        VersionText = GameObject.Find("Version Info Text");
        TutorialText = GameObject.Find("Tutorial Text");
        ChangeLogText = GameObject.Find("ChangeLog Text");
        PauseUI = GameObject.Find("Pause Screen");
        MainPlayerUI = GameObject.Find("Player Info");
        OptionsUI = GameObject.Find(" Options Screen");



        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        HealthText.GetComponent<Text>().text = "Health : " + PlayerScript.Health.ToString(); //adds health to a text base
        PointsText.GetComponent<Text>().text = "Points : " + PlayerScript.Points.ToString(); //adds points to a text base
        VersionText.GetComponent<Text>().text = "Version : Alpha " + VersionInformation.ToString(); //adds version to a text base

        if (Input.GetButton("ChangeLog"))
        { // if C is pressed then activate changelog text
            ChangeLogText.GetComponent<Text>().text = "Version : Alpha " + VersionInformation.ToString() + " Niveau Tutoriel/menu,1 et 2, Changelog, optimisation, ";
        }//puts0 this on the screen (change log)
        else
        {
            ChangeLogText.GetComponent<Text>().text = " "; //puts0 this on the screen (change log)
        }

        if (Input.GetButtonDown("Cancel")) {//if escape button is pressed then quit
            isPaused = !isPaused;
            if (!isPaused)
            {

                PauseUI.SetActive(true);
                MainPlayerUI.SetActive(false);
            }
            else
            {

                PauseUI.SetActive(false);
                MainPlayerUI.SetActive(true);
            }
            //          Application.Quit(); //kills the application
        }
    }
}
