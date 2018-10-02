//NYAN NYAN NYAN
using UnityEngine;
using System.Collections;
using Assets.Scripts.VersionEditor;
using UnityEngine.UI;

public class CameraControler : MonoBehaviour {

    public float rotateSpeed = 1.0f;
    public GameObject rotatePivot;



    private float axis;
    void Start()
    {
        transform.SetParent(rotatePivot.transform);
        rotatePivot = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        axis = Input.GetAxis("Mouse X");
        print(axis);

        rotatePivot.transform.Rotate(Vector3.up * axis * rotateSpeed * Time.deltaTime);

        rotateSpeed = GameObject.Find("Slider Sensi").GetComponent<Slider>().value;

    }
}
