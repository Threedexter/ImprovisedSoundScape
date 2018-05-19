using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject Player;
    public Camera cam;
    public AudioSource source;
    public GameObject ball;
    public ReverbScript.AreaTypes type;

    [Range(1.0f, 10.0f)]
    public float speedfactor;

    bool hasthrown = false;

    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
            if (Player == null)
            {
                Debug.Log("Player is null");
            }
        }
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    void HandleMovement()
    {
        float ForBackAxis = Input.GetAxis("Forward/Backward");
        float StrafeAxis = Input.GetAxis("Strafe");

        Vector3 camVectorFwdLocked = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 camVectorRgtLocked = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);

        if (Mathf.Abs(Input.GetAxis("Forward/Backward")) > 0)
        {
            transform.position = transform.position + (camVectorFwdLocked * Input.GetAxis("Forward/Backward") * (speedfactor / 10));
        }
        if (Mathf.Abs(Input.GetAxis("Strafe")) > 0)
        {
            transform.position = transform.position + (camVectorRgtLocked * Input.GetAxis("Strafe") * (speedfactor / 10));
        }
    }

    void HandleInteraction()
    {
        if (Input.GetButtonDown("Throw") && !hasthrown)
        {
            Vector3 camVectorFwdLocked = new Vector3(cam.transform.forward.x, cam.transform.forward.y, cam.transform.forward.z);
            Player.GetComponent<Rigidbody>().isKinematic = true;
            hasthrown = true;
            GameObject ballObject = Instantiate(ball,cam.transform.position + (camVectorFwdLocked * 2), cam.transform.rotation);
            ballObject.GetComponent<BallScript>().setType(type);

            ballObject.GetComponent<Rigidbody>().AddForce(camVectorFwdLocked * 2,ForceMode.Impulse);
            Destroy(ballObject, 20);
        }
        if (Input.GetButtonUp("Throw") && hasthrown)
        {
            Player.GetComponent<Rigidbody>().isKinematic = false;
            hasthrown = false;
        }
    }
}
