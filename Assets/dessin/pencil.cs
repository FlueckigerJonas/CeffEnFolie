using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pencil : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private KeyCode moveUp;
    [SerializeField]
    private KeyCode moveDown;
    [SerializeField]
    private KeyCode moveRight;
    [SerializeField]
    private KeyCode moveLeft;
    private float moveX = 0;
    private float moveY = 0;
    private Rigidbody2D rigBody;
    [SerializeField]
    private float timeRemaining = 0.0f;
    private pieceVelocity collision;
    [SerializeField]
    private GameObject pencil1;

    private AudioSource ads1;
    private AudioSource ads2;
    bool hasWon = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ads1 = GetComponents<AudioSource>()[0];
        ads2 = GetComponents<AudioSource>()[1];
        collision = pencil1.GetComponent<pieceVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            moveY = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            moveY = -speed;
        }
        else
        {
            moveY = 0;
        }

        if (Input.GetKey(moveRight))
        {
            moveX = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            moveX = -speed;
        }
        else
        {
            moveX = 0;
        }


        if ((moveX == 0 || moveY == 0))
        {
            rigBody.velocity = new Vector2(moveX, moveY);
        }
        else
        {
            rigBody.velocity = new Vector2(0, 0);
        }


        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            ads1.Stop();
            ads2.Stop();
            ads2.PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
            print("Lost");                                                                                         //Perdu
            StaticGameData.isLost = true;
            StartCoroutine(StaticGameData.swapScene());
        }


        if(hasWon)
        {
            print("Won");
            ads1.Stop();
            ads2.Stop();
            ads2.PlayOneShot(StaticGameData.winSoundEffect, 0.5f);                                                  //Gagné
            StaticGameData.Game.Points++;
            StartCoroutine(StaticGameData.swapScene());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "end")
        {
            hasWon = true;                                                                                        //Gagné
        }
    }
}
