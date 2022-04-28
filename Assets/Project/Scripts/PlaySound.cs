using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource playSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Takable")
        {
            playSound.Play();
        }
        if (other.gameObject.tag == "Wall")
        {
            playSound.Play();
        }
    }
}
