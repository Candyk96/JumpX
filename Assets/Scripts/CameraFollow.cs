using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float smoothTime = 0.3f;
    public GameObject Target;
    private Vector3 velocity = Vector3.zero;
    //public bool outOfMap = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
            // "smoooth" follow
            var targetPosition = new Vector3(Target.transform.position.x,
                                            Target.transform.position.y,
                                            this.transform.position.z);
            this.transform.position = Vector3.SmoothDamp(this.transform.position,
                                                    targetPosition,
                                                    ref velocity,
                                                    smoothTime);
        
            // "hard" follow
            /*this.transform.position = new Vector3(Target.transform.position.x,
                                                Target.transform.position.y,
                                                this.transform.position.z);*/
        
        
	}
}
