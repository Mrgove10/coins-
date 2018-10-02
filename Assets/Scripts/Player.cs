//NYAN NYAN NYAN
/// <- a voir plus tard
/// 
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.VersionEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed = 10; //speed of player
    public float gravity = 9.81f; //gravity
    public float maxVelocityChange = 10;
    public float jumpHeight = 2;
    public int Health; // health (int)
    public int Points = 0; //sets starting points


    private Scene CurrentScene;
    private bool grounded; //is it on the ground or not ?
    private bool dead; // if dead or not
    private bool isPaused = false; //paused or not ?
    private Transform PlayerTransform;
    private Transform TargetBlueCoin; //select the target
    private Transform TargetCoin; //select the target
    private Rigidbody _rigidbody;
    private CoinRotation OtherScriptToAccess; //scrip to acces (for coin points)
    private GameObject Coin; //to make a likn between coin and player

    // Use this for initialization
    void Start () {
        PlayerTransform = GetComponent<Transform>(); // sets player transform to trasnform component of player
        TargetBlueCoin = GameObject.FindGameObjectWithTag("CoinBlue").transform;
        _rigidbody = GetComponent<Rigidbody>(); 
        _rigidbody.useGravity = false; // deactivates rigidbody's gravity 
        _rigidbody.freezeRotation = true; // deactivates rigidbody's rotation 

    }
		
	// Update is called once per frame at a fixed time
	void FixedUpdate () {
        PlayerTransform.Rotate(0, Input.GetAxis("Horizontal") * 2, 0); //sets rotation to right or left direction (q,d, fleche droit , fleche gauche)
///     PlayerTransform.Rotate(0, 0, Input.GetAxis("Vertical"));
        Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical")); //makes player go foward or back whit (z,s,fleche avant , fleche arriere)
        targetVelocity = PlayerTransform.TransformDirection(targetVelocity);
        targetVelocity = targetVelocity * speed;

        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = targetVelocity - velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange); // makes sure we dont change direction whene we are moving
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange); //
        velocityChange.y = 0; 
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        if (Input.GetButton("Jump") && grounded == true) { //if player preses space bar then jump
            _rigidbody.velocity = new Vector3(velocity.x, CalculateJump(), velocity.z);
        }

        _rigidbody.AddForce(new Vector3(0, -gravity * _rigidbody.mass, 0)); //gravity
        grounded = false;

        TargetCoin = GameObject.FindGameObjectWithTag("Coin").transform;
        OtherScriptToAccess = TargetCoin.GetComponent<CoinRotation>(); //the scrip asociated to the 

    }
    // Update is called once per frame
    void Update()
    {

       
        

        if (Health <= 0 || Points == 12300000 + 50) { //when no more health
            SceneManager.LoadScene("Start"); // load scene tutorial
        }
        if (Points == 12300001 + 50) { //niveau 1
            SceneManager.LoadScene("1"); // goes to next scene
        }
        if (Points == 12300002 + 50) {//niveau 2
            SceneManager.LoadScene("2");// goes to next scene
        }
        if (Points == 12300003 + 50) {//niveau 3
            SceneManager.LoadScene("3"); // goes to next scene
        }
        if (Points == 12300004 + 50) {//niveau 4
            SceneManager.LoadScene("4"); // goes to next scene
        }
        if (Points == 12300005 + 50) {//niveau 5
            SceneManager.LoadScene("5"); // goes to next scene
        }



        if (Points >= 50 ) { //if it collied whit an that hast the tag tutorial   
            TargetBlueCoin.gameObject.SetActive(true);
        }
        else {
            TargetBlueCoin.gameObject.SetActive(false);
        }


     
        print("Player Points = " + Points + "; Scene = " + CurrentScene.name); //for debugging
        CurrentScene = SceneManager.GetActiveScene();
    }
    float CalculateJump() { //calculates jump 
        float Jump = Mathf.Sqrt(2 * jumpHeight * gravity); 
        return Jump;
    }

    void OnCollisionStay() {
        grounded = true;
    }

    void OnTriggerEnter(Collider Buddy) {
        if (Buddy.tag == "Coin" || Buddy.name == "CoinBlue") { //if it collied whit an object names coin
            Points = Points + Buddy.gameObject.GetComponent<CoinRotation>().PointsPerCoin; //sets points to the points currently +coins from the coin 
            Destroy(Buddy.gameObject); //destroys the coin 
            Buddy.gameObject.GetComponent<CoinRotation>().PointsPerCoin = 0;
        }

  /*      if (Buddy.tag == "Tutorial") { //if it collied whit an that hast the tag tutorial
            TutorialText.text = "Bienvenu dans COINSSS! Je doute que vous avez besoin d'un tutoriel. De toute maniere je ne l'ai pas encore fini..."; //puts this on the screen
        }

    }
    void OnTriggerExit(Collider Buddy ){
        if (Buddy.tag == "Tutorial") { //if it collied whit an that hast the tag tutorial
            TutorialText.text = ""; //puts this on teh screen
        }*/
    }
   
}

