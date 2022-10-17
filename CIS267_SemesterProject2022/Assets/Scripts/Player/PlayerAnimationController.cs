using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator playerAnimator;
    private string walkingBoolName = "isWalkingAnimatorBool";
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        setAnimation();
    }

    void setAnimation()
    {
        Debug.Log(PlayerInfo.getIsWalking());
        if(PlayerInfo.getIsWalking())
        {
            playerAnimator.SetBool(walkingBoolName, true);
        }
    }
}
