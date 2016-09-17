using UnityEngine;
using System.Collections;

public class ShowDescription : MonoBehaviour {


	private bool appear, disappear;
	private Vector3 startScale, intermediateVec;
	private float interpolStepSize;

	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
        this.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (appear) {
            if (this.transform.localScale == startScale) {
				appear = false;
			} else {
				this.transform.localScale = intermediateVec;
				intermediateVec = new Vector3 (Mathf.Lerp(intermediateVec.x,startScale.x,interpolStepSize),Mathf.Lerp(intermediateVec.y,startScale.y,interpolStepSize),Mathf.Lerp(intermediateVec.z,startScale.z,interpolStepSize));
				interpolStepSize += 0.01f;
			}
		}
		if (disappear) {
			if (this.transform.localScale == new Vector3 (0, 0, 0)) {
				disappear = false;
				this.gameObject.SetActive (false);
			} else {
				this.transform.localScale = intermediateVec;
				intermediateVec = new Vector3 (Mathf.Lerp(startScale.x,0,interpolStepSize),Mathf.Lerp(startScale.y,0,interpolStepSize),Mathf.Lerp(startScale.z,0,interpolStepSize));
				interpolStepSize += 0.01f;
			}
		}
	}

	public void sDShow (){
		interpolStepSize = 0.01f;
		intermediateVec = new Vector3 (0, 0, 0);
		appear = true;
		disappear = false;
		this.transform.localScale = intermediateVec;
		this.gameObject.SetActive (true);
	}

    public void sDHide () {
		interpolStepSize = 0.01f;
		intermediateVec = startScale;
		disappear = true;
		appear = false;
	}
}
