using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTxtDisplay : MonoBehaviour {

    private bool showTip = false;
    private float timer = 0;
    public Text BonusTxt;
    public float tipTime = 5;
   

    // Update is called once per frame
    void Update()
    {
        if (showTip)
        {
            if (timer < tipTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                BonusTxt.enabled = false;
                showTip = false;
                timer = 0;
            }
        }
    }

    void displayTipMessage(string tipText)
    {
        BonusTxt.text = tipText;
        BonusTxt.enabled = true;
        this.showTip = true;
    }
}
