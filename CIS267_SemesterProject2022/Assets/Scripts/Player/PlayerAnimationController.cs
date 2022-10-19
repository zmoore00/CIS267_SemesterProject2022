using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator playerAnimator;
    private string walkingBoolName = "isWalkingAnimatorBool";
    private string flyingBoolName = "isFlyingAnimatorBool";

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setAnimation();
    }

    void setAnimation()
    {
        if(PlayerInfo.getIsWalking() && PlayerInfo.getIsGrounded())
        {
            playerAnimator.SetBool(walkingBoolName, true);
            playerAnimator.SetBool(flyingBoolName, false);
        }
        else if(PlayerInfo.getIsFlying())
        {
            playerAnimator.SetBool(flyingBoolName, true);
            playerAnimator.SetBool(walkingBoolName, false);
        }
        else
        {
            playerAnimator.SetBool(flyingBoolName, false);
            playerAnimator.SetBool(walkingBoolName, false);
        }
    }
}
