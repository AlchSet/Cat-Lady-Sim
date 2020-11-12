using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLady : MonoBehaviour {


    public GameObject cats;

    Transform point;


    bool power;

    float elapsed;

    public float powerI;
    public delegate void Action();


    public GameObject catProp;


    public Action OnCharging;

    public Action OnRelease;


    public float min = 0.12f;
    public float max = 0.88f;

    bool waitForCat;


    public Color[] catcolors;

    SpriteRenderer holdcatsprite;
    // Use this for initialization
    void Start () {
        point = transform.Find("point");

        catProp = transform.Find("CatProp").gameObject;


        holdcatsprite = transform.Find("CatProp").Find("HeldSprite").GetComponent<SpriteRenderer>();

        int i = Random.Range(0, catcolors.Length);

        holdcatsprite.color = catcolors[i];
    }
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");


        transform.position += Vector3.right * x *4* Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, min, max);

        transform.position = Camera.main.ViewportToWorldPoint(pos);



        if (!waitForCat)
        {
            //Shoot cat
            power = Input.GetKey(KeyCode.Space);
           
        }


        if(power)
        {
            elapsed =Mathf.Clamp(elapsed+ Time.deltaTime,0,2f);

            powerI = elapsed / 2f;

            if(OnCharging!=null)
            {
                OnCharging();
            }

        }

        if(Input.GetKeyUp(KeyCode.Space)&&!waitForCat)
        {

            if (OnRelease != null)
            {
                OnRelease();
            }

            float toralForce = Mathf.Lerp(3, 7.5f, powerI);

            float toralForce2 = Mathf.Lerp(0.5f, 1, powerI);

            GameObject g = Instantiate(cats, point.position, Quaternion.identity);


            Vector3 dir = transform.forward + Vector3.up*0.5f;
            
            g.GetComponent<Rigidbody>().AddForce(dir.normalized*toralForce, ForceMode.Impulse);

            g.GetComponent<Cat>().SetCatColor(holdcatsprite.color);
            Debug.Log("Power=" + toralForce);
            power = false;
            elapsed = 0;
            powerI = 0;
            StartCoroutine(ThrowCat());
        }
	}


    IEnumerator ThrowCat()
    {
        waitForCat = true;
        catProp.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        catProp.SetActive(true);
        int i = Random.Range(0, catcolors.Length);

        holdcatsprite.color = catcolors[i];
        waitForCat = false;

    }
}
