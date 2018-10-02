//NYAN NYAN NYAN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.VersionEditor;

public class Enemy : MonoBehaviour {

    public enum state //state machine
    {
        LOOKFOR, //look for player
        GOTO, // go to player
        ATTACK, // attack player

    }
    public state CurState;
    public float Speed = 3.5f; //speed of mouvement
    public float GoToDistance = 5; //ditance to 
    public float AttackDistance = 2; //atttack distance
    public float AttackTimer = 1;//attck timer
    public Transform Target; //select the target
    public string PlayerTag = "Player"; //select the tag of the player


    private float CurTime;
    private Player PlayerScript;

	// Use this for initialization
	IEnumerator Start () {
        Target = GameObject.FindGameObjectWithTag(PlayerTag).transform;//target to follow
        CurTime = AttackTimer; //current time is attack time
        if(Target != null) {
            PlayerScript = Target.GetComponent<Player>();

        }
        while (true) { //while true = infitint update

            switch (CurState) { 
                case state.LOOKFOR: // if LOOKFOR is on the call the function LookFor
                    LookFor(); //calls lookfor
                    break; //stops calling ir
                case state.GOTO: //""
                    GoTo();
                    break;
                case state.ATTACK: // ""
                    Attack();
                    break;

            } 
            yield return 0; //prevents infitite crash

        }

	}

    void LookFor() { //funtion LookFor
        print("hi we are in lookfor");

        if(Vector3.Distance(Target.position, transform.position) < GoToDistance) { // if cloe egnouth to the goto distance then switch state
            CurState = state.GOTO;
        }
    }
    void GoTo() { //funtion GoTo
        print("hi we are in goto");
        transform.LookAt(Target); //looks at player
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit Buddy; //where the raycast hits
        if (Physics.Raycast(transform.position, fwd, out Buddy)) { //if we are hitting the do this
            if (Buddy.transform.tag != PlayerTag) { //if not hitting player dont go to player
                CurState = state.LOOKFOR; // if does hit just retun
                return;
            }
        }
        if (Vector3.Distance(Target.position, transform.position) > AttackDistance){ // if distance is lower then the attck distance the go to him
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime); //makes enemy go to player
        }
        else {
            CurState = state.ATTACK; // if close egnouth make the enemy attack
        }
    }
    void Attack() { //funtion Attack
        print("hi we are in attack ");
        transform.LookAt(Target); //looks at player
        CurTime = CurTime - Time.deltaTime*8;

        if(CurTime < 0) {
            PlayerScript.Health = PlayerScript.Health - 2; // take one health off
            CurTime = AttackTimer; //

        }

        if (Vector3.Distance(Target.position, transform.position) > AttackDistance) // if too far the go back to goto state
        {
            CurState = state.GOTO;
        }
    }
}
