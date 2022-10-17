using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkSpeed;
    public float jetPackForce;
    private float inputHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerInfo.setWalkSpeed(walkSpeed);
        PlayerInfo.setJetPackForce(jetPackForce);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jetPack();
    }

    void movePlayer()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(PlayerInfo.getWalkSpeed() * inputHorizontal, rb.velocity.y);

        if(inputHorizontal != 0)
        {
            PlayerInfo.setIsWalking(true);
        }
        else
        {
            PlayerInfo.setIsWalking(false);
        }


        flipPlayerSprite();
    }

    void flipPlayerSprite()
    {
        if(inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void jetPack()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * PlayerInfo.getJetPackForce(), ForceMode2D.Force);
            //rb.velocity = new Vector2(rb.velocity.x, PlayerInfo.getJetPackForce());
        }
    }
}
