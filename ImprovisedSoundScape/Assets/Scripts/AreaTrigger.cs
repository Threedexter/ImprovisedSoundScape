using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {

    public ReverbScript reverbHandler;
    public ReverbScript.AreaTypes reverbType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            reverbHandler.ChangeReverb(reverbType);
        }
        if(other.tag == "Ball")
        {
            BallScript ball = other.gameObject.GetComponent<BallScript>();
            ball.setType(reverbType);
        }
    }
}
