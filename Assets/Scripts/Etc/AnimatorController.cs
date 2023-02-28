using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator camShake;
    

    private void Start()
    {
        Wall.ChangeStack += Shake;
    }

    public void Shake()
    {
        camShake.SetTrigger("shape");
        
    }
    
    private void OnDestroy()
    {
        Wall.ChangeStack -= Shake;
    }
}
