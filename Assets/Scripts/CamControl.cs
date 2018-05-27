using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
    public float lerpAmnt;
    Vector3 truePos;

    public float shakeTimer;
	public float shakeTimertest; 

    public float shakeIntensity;
    public static CamControl me;
    // Use this for initialization
    void Start () {
        me = this;
		truePos = new Vector3 (0, 0, -10); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (truePos);
		if (shakeTimer > 0 ) {
			transform.localPosition = truePos + Random.insideUnitSphere * shakeIntensity;
			shakeTimer -= Time.deltaTime;
		} else {
			transform.position = truePos;
		}
//        Vector2 shake = Vector2.zero;
//        if (shakeTimer > 0) {
//            shakeTimer--;
//            shake = Random.insideUnitCircle * shakeIntensity;
//        }
//        transform.position = truePos + shake;
//
//        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
//        
//	}

//    public void Shake(float intensity, int time) {
//        shakeTimer = Mathf.Max(shakeTimer, time);
//        shakeIntensity = Mathf.Max(shakeIntensity, intensity);
//    }

}
	void shake(){
		shakeTimer = shakeTimertest; 
	}
}
