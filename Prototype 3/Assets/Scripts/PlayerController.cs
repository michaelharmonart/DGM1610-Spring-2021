using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityMultiplier = 2f;
    public bool isOnGroud = true;
    public BoolData gameOver;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound,deathSound;

    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;

    void Start()
    {
        gameOver.data = false;   
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGroud && !gameOver.data)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.2f);
            dirtParticles.Stop();
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGroud = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGroud = true;
            dirtParticles.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver.data = true;
            playerAudio.PlayOneShot(deathSound, 0.75f);
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
        }

    }
}
