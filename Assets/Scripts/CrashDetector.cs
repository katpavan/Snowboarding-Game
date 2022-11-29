using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Ground" && !crashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            
            crashEffect.Play();
            //doing this because we may want to play many different sound effects with the player
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            
            Invoke("ReloadScene", 0.3f);
            Debug.Log("head hit ground");
            crashed = true;
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
