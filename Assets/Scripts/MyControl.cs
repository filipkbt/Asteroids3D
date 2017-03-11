using System;
using UnityEngine;
using UnityEngine.UI;

public class MyControl : MonoBehaviour
{
	#region Constants
	private const string MouseScrollWheel = "Mouse ScrollWheel";
	private const string Vertical = "Vertical";
	private const string Horizontal = "Horizontal";
	private const string Bullet = "Bullet";
	private const string Roll = "Roll";

	#endregion

	#region Public Variables

	public int Health;
	public float speed;
	public float acceleration;
	public float maxSpeed;
	public float minSpeed;
	public float trueSpeed;
	public float turnSpeed;
	public Rigidbody rb;
	public GameObject bullet1;
	public AudioClip ShootLaser1;
	public int reload;
	public ParticleSystem SpeedBonusEffect;
	public ParticleSystem ShieldBonusEffect;
	public float booster = 100;
	public bool Immunity = false;
    
	#endregion

	#region Private Variables
	private DateTime lastInstantite = DateTime.MinValue;
	private AudioSource audioSource;
	private Vector2 pozycjaCelownika;
	private float boost { get; set; }
	private bool isPause = false;
	#endregion

	public float Boost
	{
		get
		{
			return this.boost;
		}
		set
		{
			this.boost = value;
		}
	}

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
		isPause = false;
		StopEffects();
	}


	void Update()
	{
		CursorRange();
		shipControlUpdate();
		buttonPress();
        ImmunityCheck();

    }
	private void shipControlUpdate()
	{
		float roll = Input.GetAxis(Roll); // q e
		float horizontal = Input.GetAxis(Horizontal) + pozycjaCelownika.x / 500; // a d
		float vertical = Input.GetAxis(Vertical) + (pozycjaCelownika.y / 500) * (-1); //w s
		float power = Input.GetAxis(MouseScrollWheel); 



		trueSpeed = Math.Min(trueSpeed, maxSpeed);
		trueSpeed = Math.Max(trueSpeed, minSpeed);

		trueSpeed += power * acceleration;

		rb.AddRelativeTorque(vertical * (turnSpeed + boost) * Time.deltaTime, horizontal * (turnSpeed + boost) * Time.deltaTime, roll * (turnSpeed + boost) * Time.deltaTime); //Zwrot
		rb.AddRelativeForce(0, 0, (trueSpeed + boost) * speed); //Pęd

	}

	void OnCollisionEnter(Collision other) //Śmierć
	{
		if (!Immunity)
		{
			if (other.gameObject.tag != Bullet)
			{
				Health--;
               
            }
		
		}
	}

	private void buttonPress()
	{
        if (Input.GetKeyDown("escape"))
        {

            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                ShipGui shipGui = GetComponent<ShipGui>();
                shipGui.pauseWindow.SetActive(true);
            }
            else 
            {
                ShipGui shipGui = GetComponent<ShipGui>();
                isPause = false;
                shipGui.pauseWindow.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			boost = booster;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			boost = 0;
		}
		if (Input.GetKey(KeyCode.Space))
		{

				audioSource.clip = ShootLaser1;
				audioSource.Play();
				Fire(bullet1);
			
		}
		
	}

	private void Fire(GameObject bullet)
	{
		Instantiate(bullet, transform.position, rb.transform.localRotation);

	}

	private int GetRangedValue(float value, int min, int max)
	{
		if (value < min)
		{
			return min;
		}

		if (value > max)
		{
			return max;
		}

		return (int)value;
	}

	private void CursorRange()
	{
		pozycjaCelownika = Input.mousePosition;

		if ((pozycjaCelownika.x - (Screen.width / 2)) > -100 && (pozycjaCelownika.x - (Screen.width / 2)) < 100)
		{
			pozycjaCelownika.x = 0;
		}
		else
		{
			if ((pozycjaCelownika.x - (Screen.width / 2) <= -100))
			{
				pozycjaCelownika.x = -100;
			}
			if ((pozycjaCelownika.x - (Screen.width / 2) >= 100))
			{
				pozycjaCelownika.x = 100;
			}
		}

		if ((pozycjaCelownika.y - (Screen.height / 2)) > -100 && (pozycjaCelownika.y - (Screen.height / 2)) < 100)
		{
			pozycjaCelownika.y = 0;
		}
		else
		{
			if ((pozycjaCelownika.y - (Screen.height / 2) <= -100))
			{
				pozycjaCelownika.y = -100;
			}
			if ((pozycjaCelownika.y - (Screen.height / 2) >= 100))
			{
				pozycjaCelownika.y = 100;
			}
		}
	}

	public void StopEffects()
	{
		SpeedBonusEffect.Stop();
		ShieldBonusEffect.Stop();
	}
    public void ImmunityCheck()
    {
        if(!ShieldBonusEffect.isPlaying)
        {
            Immunity = false;
        }
    }

}
