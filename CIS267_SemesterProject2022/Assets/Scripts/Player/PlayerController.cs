using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkSpeed;
    public float jetPackForce;
    private float inputHorizontal;

    //Called only once during the lifetime of the script
    //Called after all objects are initialized
    //used to initialize variables
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        PlayerInfo.setWalkSpeed(walkSpeed);
        PlayerInfo.setJetPackForce(jetPackForce);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //FixedUpdate is called at a fixed interval independent of frame rate.
    //Used to handle any physics in the game
    void FixedUpdate()
    {
        movePlayer();
        jetPack();
    }

    // Update is called once per frame
    // animations and user input
    void Update()
    {
        inputController();
        flipPlayerSprite();
    }

    void inputController()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0)
        {
            PlayerInfo.setIsWalking(true);
        }
        else
        {
            PlayerInfo.setIsWalking(false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            PlayerInfo.setIsFlying(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            PlayerInfo.setIsFlying(false);
        }
    }

    void movePlayer()
    {

        if (PlayerInfo.getIsFlying() || PlayerInfo.getIsGrounded())
        {
            rb.velocity = new Vector2(PlayerInfo.getWalkSpeed() * inputHorizontal, rb.velocity.y);
        }
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
        if(PlayerInfo.getIsFlying())
        {
            rb.AddForce(Vector2.up * PlayerInfo.getJetPackForce(), ForceMode2D.Force);
            //rb.velocity = new Vector2(rb.velocity.x, PlayerInfo.getJetPackForce());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Walkable"))
        {
            PlayerInfo.setIsGrounded(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Walkable"))
        {
            PlayerInfo.setIsGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Walkable"))
        {
            PlayerInfo.setIsGrounded(false);
        }
    }
}
