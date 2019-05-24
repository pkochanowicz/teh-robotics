using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pararellaxing : MonoBehaviour {

    public Transform[] backgrounds; //list of all back and foregrounds to be paralleled
    private float[] parallaxScales; //proportion of the camera's movement to move the backgrounds by
    public float smoothing =1f; //smoothness of paralax (above 0)

    private Transform _camera; //reference to the main camera transform
    private Vector3 _previousCameraPosition;

    private void Awake()
    {
        _camera = Camera.main.transform;  
    }

    // Use this for initialization
    void Start () {
        //The previous frame had the current frame's camera position
        _previousCameraPosition = _camera.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<backgrounds.Length; i++)
        {
            //the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float _parallax = (_previousCameraPosition.x - _camera.position.x) * parallaxScales[i];
            // set a target x position which is the current position plus the parallax
            float _backgroundTargetPositionX = backgrounds[i].position.x + _parallax;
            // create a target position which is the background's current position with its target x position
            Vector3 _backgroundTargetPosition = new Vector3(_backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);
            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, _backgroundTargetPosition, smoothing * Time.deltaTime);
        }
        // set the previousCameraPosition to the camera's position at the end of the frame
        _previousCameraPosition = _camera.position;
	}
}
