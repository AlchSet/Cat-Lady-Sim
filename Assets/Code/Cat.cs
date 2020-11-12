using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Rigidbody body;

    bool RunAway;

    Animator anim;

    public Color catColor;

    SpriteRenderer catSprite;

    AudioSource sfx;
    // Use this for initialization
    void Awake()
    {
        sfx = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        catSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RunAway)
        {
            body.MovePosition(transform.position + Vector3.right * 10 * Time.deltaTime);



        }
    }


    public void SetCatColor(Color c)
    {
        catSprite.color = c;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Grounded");
            body.isKinematic = true;
            RunAway = true;
            anim.SetBool("Run", true);

            float r = Random.Range(1f, 1.5f);
            sfx.pitch = r;
            sfx.PlayOneShot(sfx.clip);

        } if(collision.collider.gameObject.layer==LayerMask.NameToLayer("NPC"))
        {
            collision.collider.gameObject.GetComponent<NPC>().RunAway();
            Destroy(gameObject);
        }
    }
}
