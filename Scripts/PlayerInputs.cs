using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Rigidbody2D player_rb;
    [Header("Movement Mechanic")]
    public float speedMovement,runningSpeedMovement,aceleration,maxRunningMovement,timeToRun;

    public LayerMask whatIsGround;
    private bool grounded,isRun,playerIsCrouch,isLookUp;
    public PlayerAnimations playerAnimations;
 
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        maxRunningMovement = 7;
        aceleration = 400;
        playerAnimations = GetComponent<PlayerAnimations>();
        timeToRun = 5f * Time.deltaTime;

    }
    
    void Update()
    {
        PlayerIdle();
        PlayerMovement();
        WhenPlayerIsCrouch();
        Crouch();
        WhenPlayerLookUp();
        LookUp();
     
    }

    #region WhenPlayerMoves

    void PlayerIdle()
    {
        if (player_rb.velocity == Vector2.zero)
        {
            runningSpeedMovement = speedMovement;
            playerAnimations.setPlayerState(0);
        }
        else
        {
            playerAnimations.setPlayerState(1);
           
        }
    }
    
    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(Input.GetKey(KeyCode.A))
            {
                isRun = true;
                RunLeft();
             

            }
            else if(!Input.GetKey(KeyCode.A))
            {
                isRun = false;
                WalkLeft();
            }

        }
        
      
       
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.A))
            {
                isRun = true;
                RunRight();
               
            }
            else if(!Input.GetKey(KeyCode.A))
            { 
                isRun = false;
                WalkRight();
                
            }
            
        }
        
        else
        {
            isRun = false;
            
            player_rb.velocity = Vector2.zero;
        }

        
    }

    #endregion
   

    

    #region WalkMovement

    void WalkLeft()
    {
        playerAnimations.setPlayerState(1);
        transform.localScale = new Vector3(-1, 1, 1);
        player_rb.velocity = Vector2.left * speedMovement;
    }
    void WalkRight()
    {
        playerAnimations.setPlayerState(1);
        transform.localScale = new Vector3(1, 1, 1);
        player_rb.velocity = Vector2.right * speedMovement;
       
    }

    #endregion

    #region RunMovement

    void RunLeft()
    {
        playerAnimations.setPlayerState(2);
        runningSpeedMovement = 5;
        transform.localScale = new Vector3(-1, 1, 1);
        
        
        if (runningSpeedMovement < maxRunningMovement)
        {
            runningSpeedMovement = runningSpeedMovement + aceleration * Time.deltaTime;
            player_rb.velocity = Vector2.left * runningSpeedMovement;
        }
      
       
      
    }
    void RunRight()
    {
        playerAnimations.setPlayerState(2);
        runningSpeedMovement = 5;
        transform.localScale = new Vector3(1, 1, 1);
     
        if (runningSpeedMovement < maxRunningMovement)
        {
            runningSpeedMovement = runningSpeedMovement + aceleration * Time.deltaTime;
            player_rb.velocity = Vector2.right * runningSpeedMovement;
        }
     
       
    }


   
    #endregion

   
    void Jump()
    {
        
    }

   #region CrouchInput
   void Crouch()
   {
       if (playerIsCrouch)
       {
           playerAnimations.setPlayerState(4);
           player_rb.velocity = Vector2.zero;
       }
       else if(!playerIsCrouch)
       {
         
   
           return;
       }
       
   }
   void WhenPlayerIsCrouch()
   {
       if (Input.GetKey(KeyCode.DownArrow))
       {
           playerIsCrouch = true;
       }
       else
       {
           playerIsCrouch = false;
       }
   }
   #endregion

   #region LookUpInput
   void LookUp()
   {
       if (isLookUp)
       {
           playerAnimations.setPlayerState(5);
           player_rb.velocity = Vector2.zero;
       }
       else if(!isLookUp)
       {
          
           return;
       }
   }
   void WhenPlayerLookUp()
   {
       if (Input.GetKey(KeyCode.UpArrow))
       {
           isLookUp = true;
       }
       else
       {
           isLookUp = false;
       }
   }
   

   #endregion 
  
    
}
