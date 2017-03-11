using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeed : MonoBehaviour {

	#region Constants
	private const string Player = "Player";
	#endregion

	#region
	public int SpeedPoints;
	public ParticleSystem SpeedBonusBall;
	#endregion

	#region Private Variables
	bool isOn = false;
	private MyControl myControl;
	#endregion

	void Start () {}
	
	void Update () {
		if(isOn)
		{
			if (myControl.SpeedBonusEffect.isPlaying)
			{
				myControl.Boost = SpeedPoints;
			}
			else
			{
				myControl.Boost = 0;
				Destroy(this.gameObject);
			}
		}
		
	}

		public void OnTriggerEnter(Collider other)
	{
		if(other.tag == Player)
		{
            

            
            myControl = other.GetComponent<MyControl>();
            other.SendMessage("displayTipMessage", "SPEEEEEEED!");
            myControl.SpeedBonusEffect.Play();
			this.SpeedBonusBall.Stop();
			isOn = true;
		}
	}
}
