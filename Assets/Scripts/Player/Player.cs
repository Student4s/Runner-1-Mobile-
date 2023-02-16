using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canMove=false;
    [SerializeField] private int countOfStacks = 0;
    [SerializeField] private GameObject playerCube;
    [SerializeField] private Animator playerAnim;
    
    private Touch touch;
    [SerializeField] private float sideSpeed;
    [SerializeField] private float roadWidth;
    
    public delegate void CubeStacks();
    
    public static event CubeStacks ActivateStackEffect;

    
    public delegate void PlayerDeath();

    public static event PlayerDeath Dead;
    void Start()
    {
        Velcro.ChangeStack += Change;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +speed * Time.deltaTime);
            speed += Time.deltaTime * 0.1f;

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        Math.Clamp(transform.position.x + touch.deltaPosition.x * sideSpeed, -roadWidth, roadWidth),
                        transform.position.y, transform.position.z);
                }
            }
        }
        
    }

    private void Change()
    {
        countOfStacks -= 1;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Stackable"))
        {
            countOfStacks += 1;
            ActivateStackEffect();
            playerCube.transform.localPosition += new Vector3(0, 1.01f, 0);
            other.transform.parent = playerCube.transform;
            other.transform.localPosition = new Vector3(0, -countOfStacks, 0);
            PlayJumpAnimation();
        }
    }

    public void StartGame()
    {
        canMove = true;
    }

    public void Death()
    {
        canMove = false;
        Dead();
    }
    
    public void PlayJumpAnimation()
    {
        playerAnim.SetTrigger("Jump");
    }


    private void OnDestroy()
    {
        Velcro.ChangeStack -= Change;
    }
}