using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    /*
     *
     *STATES
     * 0-idle
     * 1- walk
     * 2-run
     * 3-jump
     * 4-crouch
     * 5-lookUp
     * 6-lookOut
     * 
     */
    private Animator player_animator;
    void Start()
    {
        player_animator = GetComponent<Animator>();
    }

   

    public void setPlayerState(int playerState)
    {
        player_animator.SetInteger("state",playerState);
    }

   
}
