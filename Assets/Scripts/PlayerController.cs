using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 7f;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    public void DisableControls(){
        canMove = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent <Rigidbody2D>();
        //this is fine because we have only one SurfaceEffector2D component on the Level Sprite Shape (the mountain)
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update(){
        if (canMove){
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RespondToBoost(){
        if (Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector2D.speed = boostSpeed;
        }else if (Input.GetKey(KeyCode.DownArrow)){
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}