using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ReverbScript : MonoBehaviour
{

    public enum AreaTypes { SmallInside, LargeInside, Outside, Cathedral };

    public GameObject[] Areas;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeReverb(AreaTypes type)
    {
        Player.GetComponent<PlayerControl>().type = type;
    }
}
