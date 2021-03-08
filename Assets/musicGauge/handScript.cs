using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScript : MonoBehaviour
{
    private AudioSource music;

    [SerializeField]
    private KeyCode space;

    [SerializeField]
    private GameObject hand;

    private float rotation = 0;

    bool hasLost = false;
    bool hasWon = false;

    bool rightToLeft = true;

    [SerializeField]
    private float timer = 5;

    [SerializeField]
    private int speed = 200;

    [SerializeField]
    private int green = 20;

    // Start is called before the first frame update
    void Start()
    {
        //music = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasWon && !hasLost)
        {
            if (timer < 0)
            {
                hasLost = true;
                print("lose");
                //GetComponent<AudioSource>().Stop();
                //GetComponent<AudioSource>().PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
                StaticGameData.isLost = true;
                //StartCoroutine(StaticGameData.swapScene());
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if(Input.GetKey(space) && !hasWon)
            {
                hand.transform.Rotate(0f, 0f, 0f);
                if(rotation > (-green) && rotation < green)
                {
                    print("win");
                    //music.Stop();
                    //music.PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
                    hasWon = true;
                    //StaticGameData.Game.Points++;
                    //StartCoroutine(StaticGameData.swapScene());
                }
            }
            else if(!hasWon)
            {
                if(rightToLeft)
                {
                    float rotationAmount = speed * Time.deltaTime;
                    hand.transform.Rotate(0f, 0f, -rotationAmount);
                    rotation -= rotationAmount;
                    if(rotation < -90)
                    {
                        rightToLeft = false;
                    }
                }
                else
                {
                    float rotationAmount = speed * Time.deltaTime;
                    hand.transform.Rotate(0f, 0f, rotationAmount);
                    rotation += rotationAmount;
                    if (rotation > 90)
                    {
                        rightToLeft = true;
                    }
                }
            }
        }
    }
}
