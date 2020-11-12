using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour {

    public CatLady catlady;

    Slider slider;

    CanvasGroup g;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        g = GetComponent<CanvasGroup>();

        g.alpha = 0;
        g.interactable = false;

        catlady.OnCharging = UpdateAndShowSlider;
        catlady.OnRelease = ResetAndHideSlider;
        //lider.

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void UpdateAndShowSlider()
    {
        slider.value =catlady.powerI;
        g.alpha =1;
        //g.interactable = false;
    }

    public void ResetAndHideSlider()
    {
        slider.value = 0;
        g.alpha = 0;
        //g.interactable = false;
    }
}
