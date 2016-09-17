using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Vector3 v1;
    public Vector3 v2;
    public float alpha; //Angle between the plane normal and the observer
    public Quaternion p; //Quaternion of plane
    public Quaternion c; //Quaternion of camera wrt plane
    public int range = 45; //Maximum absolute tilting angle
    public GameObject refplane; //Reference Plane


    // Use this for initialization
    void Start() {
        //v1 = GameObject.Find("ReferencePlane").transform.up;
        //Debug.DrawRay(GameObject.Find("ReferencePlane").transform.position, GameObject.Find("ReferencePlane").transform.up, Color.red);

        //gameObject.transform.position = GameObject.Find("ReferencePlane").transform.position;
        p = refplane.transform.rotation;
        

	}
	
	// Update is called once per frame
	void Update () {
        //        v2 = GameObject.Find("Main Camera").transform.position - gameObject.GetComponentInParent<Transform>().transform.position;
        //v2 = GameObject.Find("Main Camera").transform.position - GameObject.Find("ReferencePlane").transform.position;
        v2 = GameObject.Find("Main Camera").transform.position - refplane.transform.position;
        //c = Quaternion.LookRotation(v1, v2);

        c = Quaternion.LookRotation(Vector3.up,v2);
        gameObject.transform.rotation = c;

//        alpha = Quaternion.Angle(p, c);
//        if (-range < alpha && alpha < range)
//        {
//            gameObject.transform.rotation = c;
//        }
	}
}
