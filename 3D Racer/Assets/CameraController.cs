using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float distanceAbove;
    public float distanceBehind;
    private float accumRotation;

    private float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Q))
        {
            accumRotation++;
        } else if (Input.GetKey(KeyCode.E))
        {
            accumRotation--;
        }
        transform.position = target.position - (target.forward * distanceBehind) + (Vector3.up * distanceAbove * (Input.mousePosition.y * 0.1f));
        transform.LookAt(target);
        transform.RotateAround(target.transform.position, Vector3.up, Input.mousePosition.x * 0.5f);
	}
}
