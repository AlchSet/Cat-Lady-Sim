using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{


    public int facingDir = 1;

    public float speed = 1.5f;

    bool runAway;
    GameObject catFight;

    Animator anim;
    AudioSource sfx;


    public AudioClip[] sfxs;


    public delegate void Action(int i);

    public static Action OnHitNPC;


    public int scoreVal = 100;
    // Use this for initialization
    void Awake()
    {
        sfx = GetComponent<AudioSource>();
        catFight = transform.Find("CatFight").gameObject;
        catFight.SetActive(false);
        //transform.localScale = new Vector3(facingDir, 1, 1);

        anim = GetComponentInChildren<Animator>();

        int i = Random.Range(0, 4);

        speed = Random.Range(0.5f, 2.5f);
        switch (i)
        {
            case 0:
                anim.Play("TopHat");
                scoreVal = 100;
                break;


            case 1:
                scoreVal = 200;
                anim.Play("Postman");
                break;

            case 2:
                scoreVal = 300;
                anim.Play("Runner");
                break;
            case 3:
                scoreVal = 500;
                anim.Play("Raincoat");
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!runAway)
            transform.Translate(Vector3.right * facingDir * speed * Time.deltaTime);
        else
        {
            transform.Translate(Vector3.right * -facingDir * 10 * Time.deltaTime);
        }
    }


    public void ConfigureFaceDir(int dir)
    {
        facingDir = dir;

    }


    public void RunAway()
    {
        int r = Random.Range(0, sfxs.Length);
        //Debug.Log(r);

        float rp = Random.Range(.8f, 1.3f);
        sfx.pitch = rp;

        sfx.PlayOneShot(sfxs[r]);
        runAway = true;
        catFight.SetActive(true);
        if (OnHitNPC != null)
            OnHitNPC(scoreVal);
    }

    public void Init(float dir)
    {
        facingDir = (int)dir;
        catFight.SetActive(false);
        runAway = false;

        int i = Random.Range(0, 4);

        speed = Random.Range(0.5f, 2.5f);
        switch (i)
        {
            case 0:
                anim.Play("TopHat");
                break;


            case 1:
                anim.Play("Postman");
                break;

            case 2:
                anim.Play("Runner");
                break;

            case 3:
                scoreVal = 500;
                anim.Play("Raincoat");
                break;

        }
        transform.localScale = new Vector3(facingDir, 1, 1);
    }
}
