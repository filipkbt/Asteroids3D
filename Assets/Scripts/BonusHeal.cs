using UnityEngine;

public class BonusHeal : MonoBehaviour {

	#region Constatns
	private const string ThePlayer = "Player";
	#endregion

	#region Public Variables
	public int HealPoints;
	#endregion

	void Start () {}
	
	void Update () {}

	public void OnTriggerEnter(Collider other)
	{
        if (other.tag == ThePlayer)
        {
            int addedHP;

           MyControl myControl = other.GetComponent<MyControl>();
            if (myControl.Health >= 10)
                other.SendMessage("displayTipMessage", "Don't waste potions ! Your health is full.");
            else
            {
                if (myControl.Health <= 9 && myControl.Health >= 5)
                {
                    addedHP = 10 - myControl.Health;
                    myControl.Health += addedHP;
                }
                else
                {
                    addedHP = HealPoints;
                myControl.Health += addedHP;
            }

                other.SendMessage("displayTipMessage", "Your health has been increased +" + addedHP + "hp");

            
            }
			Destroy(this.gameObject);
		}
	}
}
