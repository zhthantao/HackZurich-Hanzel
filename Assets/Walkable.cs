using UnityEngine;
using System.Collections;

public class Walkable : MonoBehaviour {

	// Use this for initialization
	void Start () {	
	}

    // Update is called once per frame
    void Update() {
        if ( transform.forward.y < -0.6f && transform.position.x + 0.05f * transform.forward.x > - 3.64f && transform.position.x + 0.05f * transform.forward.x < 3.8f) {
            //Debug.Log("Forward =" + transform.forward);
            transform.position = new Vector3(transform.position.x + 0.05f * transform.forward.x, transform.position.y, transform.position.z);
        }
    }
}
