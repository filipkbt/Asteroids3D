using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour {

	#region Constants
	private const string Player = "Player";
	#endregion

	#region
	public ParticleSystem BonusBall;
	#endregion

	#region Private Variables
	bool isOn = false;
	private MyControl myControl;

	#endregion

	void Start() { }

	void Update()
	{
		if (isOn)
		{
			if (!myControl.ShieldBonusEffect.isPlaying)
			{
               
                myControl.Immunity = false;
				Destroy(this.gameObject);
			}
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == Player)
        {

            MyControl myControl = other.GetComponent<MyControl>();
            myControl.ShieldBonusEffect.Play();
            

            other.SendMessage("displayTipMessage", "You are immortal. Don't waste it !");
            this.BonusBall.Stop();
			myControl.Immunity = true;
			isOn = true;
		}
	}
}
