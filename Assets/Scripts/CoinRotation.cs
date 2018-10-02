//NYAN NYAN NYAN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.VersionEditor;

public class CoinRotation : MonoBehaviour {
    public float speed = 5; //speed of rotation
    public int RandomNumber; //generats a random int umber
    public int PointsPerCoin = 0; //points for a certain coin ,0 being the base 


    // Use this for initialization
    void Start () {
        RandomNumber = Random.Range(1, (int)speed); // takes the random number and multiplies it by the speed
   
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * (RandomNumber * 1.0f)); //makes teh cube rotate
	}
}



