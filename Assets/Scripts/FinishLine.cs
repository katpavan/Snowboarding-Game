using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.7f;
    
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
            Debug.Log("you finished");
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}