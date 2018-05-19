using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    enum ClipTypes { Bounce = 0, Dog, Cat, Bell };

    public ReverbScript.AreaTypes type;
    public AudioClip[] clips;
    public AudioSource source;
    public PlayerControl player;

    private bool playAudio = true;

    private void Update()
    {
        if(this.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            playAudio = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground" && playAudio)
        {
            float distvolume = 1 / (Mathf.Clamp(Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position), 0, 20) / 20);
            float speedVolume = Mathf.Clamp(this.GetComponent<Rigidbody>().velocity.y, 0, 10)/10;
            Debug.Log("Volume:" + distvolume * speedVolume);
            source.volume = distvolume * speedVolume;
            switch(type)
            {
                case ReverbScript.AreaTypes.SmallInside:
                    {
                        source.PlayOneShot(clips[(int)ClipTypes.Dog]);
                        break;
                    }
                case ReverbScript.AreaTypes.LargeInside:
                    {
                        source.PlayOneShot(clips[(int)ClipTypes.Cat]);
                        break;
                    }
                case ReverbScript.AreaTypes.Outside:
                    {
                        source.PlayOneShot(clips[(int)ClipTypes.Bell]);
                        break;
                    }
                case ReverbScript.AreaTypes.Cathedral:
                    {
                        source.PlayOneShot(clips[(int)ClipTypes.Bounce]);
                        break;
                    }
            }
        }
    }

    public void setType(ReverbScript.AreaTypes areaType)
    {
        type = areaType;
    }
}
