using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour {

    public GameObject[] leftSpawns;
    public GameObject[] rightSpawns;

    public GameObject NPC;


    bool spawn;

    float elapsed;

    List<NPC> npclist=new List<NPC>();


    int npcIndex;

	// Use this for initialization
	void Start () {


        for(int i=0;i<20;i++)
        {
            GameObject g = Instantiate(NPC, Vector3.up*100,Quaternion.identity);
            g.transform.position = Vector3.up * 100;
            npclist.Add(g.GetComponent<NPC>());

        }


        float r = Random.Range(0f, 1f);

        if (r > .5f)
        {

            int rr = Random.Range((int)0, (int)leftSpawns.Length - 1);

            GameObject g = Instantiate(NPC, leftSpawns[rr].transform.position, Quaternion.identity);
            //g.GetComponent<NPC>().ConfigureFaceDir(1);


        }
        else
        {
            int rr = Random.Range((int)0, (int)rightSpawns.Length - 1);

            GameObject g = Instantiate(NPC, rightSpawns[rr].transform.position, Quaternion.identity);
            //g.GetComponent<NPC>().ConfigureFaceDir(-1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		



        if(!spawn)
        {
            float r = Random.Range(0f, 1f);

            if (r > .5f)
            {

                int rr = Random.Range((int)0, (int)leftSpawns.Length);

                //GameObject g = Instantiate(NPC, leftSpawns[rr].transform.position, Quaternion.identity);
                //g.GetComponent<NPC>().ConfigureFaceDir(1);

                NPC n = npclist[npcIndex];

                npcIndex = (npcIndex + 1) % npclist.ToArray().Length;

                n.transform.position = leftSpawns[rr].transform.position;


                n.Init(1);
                //n.ConfigureFaceDir(1);
                //n.Init();
            }
            else
            {
                int rr = Random.Range((int)0, (int)rightSpawns.Length);

                //GameObject g = Instantiate(NPC, rightSpawns[rr].transform.position, Quaternion.identity);
                //g.GetComponent<NPC>().ConfigureFaceDir(-1);


                NPC n = npclist[npcIndex];

                npcIndex = (npcIndex + 1) % npclist.ToArray().Length;

                n.transform.position = rightSpawns[rr].transform.position;

                

                //n.ConfigureFaceDir(-1);
                n.Init(-1);

            }
            spawn = true;

        }
        else
        {
            elapsed += Time.deltaTime;

            if (elapsed>2)
            {
                spawn = false;
                elapsed = 0;
            }
        }
	}
}
