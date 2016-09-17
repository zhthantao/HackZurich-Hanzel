using UnityEngine;
using System.Collections;
using System;

public class BuyText : MonoBehaviour {

	private bool sd1,sd2,sd3;

	private DateTime start;

	// Use this for initialization
	void Start () {
		start = DateTime.Now;
	}

	void OnGUI(){

		if (DateTime.Now.Subtract (start).TotalSeconds < 10) {
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 100, Screen.height - 300, 200, 300));
			GUILayout.Label ("Purchase successful!");
			GUILayout.Label ("Missing items have been added to your list");
			GUILayout.EndArea ();
		
		}

		if (sd1) {
			GUILayout.BeginArea (new Rect(0,Screen.height-150,200,300));
			GUILayout.Label ("Bamboo skewers");
			GUILayout.Label ("1 cucumber");
			GUILayout.Label ("1 small onion");
			GUILayout.Label ("Oil");
			GUILayout.EndArea();
		}
		if (sd2) {
			GUILayout.BeginArea (new Rect(0,Screen.height-150,200,300));
			GUILayout.Label ("Butter");
			GUILayout.Label ("Garlic");
			GUILayout.Label ("Salt");
			GUILayout.Label ("Honey");
			GUILayout.Label ("Thyme or parsley");
			GUILayout.EndArea();
		}
		if (sd3) {
			GUILayout.BeginArea (new Rect(0,Screen.height-150,200,300));
			GUILayout.Label ("Small red onion");
			GUILayout.Label ("Roasted peanuts");
			GUILayout.Label ("Salt");
			GUILayout.Label ("Chopped cilantro");
			GUILayout.EndArea();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
