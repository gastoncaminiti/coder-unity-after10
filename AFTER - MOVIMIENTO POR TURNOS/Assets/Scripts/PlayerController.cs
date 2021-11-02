using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 5f;
    [SerializeField] private float cameraAxisX = -90f;

    [SerializeField] AudioClip clipWalk;
    [SerializeField] AudioClip clipShoot;


    // Start is called before the first frame update
    private bool isRun   = false;
    private bool isShoot = false;
    private bool isTurn  = false;

    private Animator animPlayer;

    private AudioSource audioPlayer;


    void Start()
    {
        animPlayer = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurn) { 
            RotatePlayer();
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ResetShoot();
            }

            animPlayer.SetBool("isRun", isRun);
            animPlayer.SetBool("isShoot", isShoot);
        }
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");

        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            isRun = true;
            Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical);
            transform.Translate(speedPlayer * Time.deltaTime * direction);
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.PlayOneShot(clipWalk, 0.5f);
            }
        }
        else
        {
            isRun = false;
        }
    }
    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = angulo;
    }

    private void Shoot()
    {
        Debug.Log("SHOOOOOOOOOOOOOOOT");
        audioPlayer.PlayOneShot(clipShoot, 1f);
        isShoot = true;
    }

    private void ResetShoot()
    {
        Debug.Log("NO SHOOT");
        isShoot = false;
    }

    public void setTurn()
    {
        isTurn = true;
    }

}
