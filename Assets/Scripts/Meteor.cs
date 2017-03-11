using UnityEngine;

public class Meteor : MonoBehaviour
{
	#region Public Variables
	public GameObject MeteorChild;
	public bool IfDest;
	public float Health;
	public int Points;
	public ParticleSystem Explosion;
	public AudioClip Boom;
	#endregion

	#region Private Variables
	private AudioSource audioSource;
	private int rand;
	private SphereCollider colid;
	#endregion

	void Start()
	{
		Explosion.Stop();
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		checkIfDie();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			LaserScript script = other.GetComponent<LaserScript>();			//Pobierz obrażenia pocisku i odejmij od HP
			Health -= script.damage;
			Destroy(other.gameObject);
		}
	}

	private void checkIfDie()
	{
		if (Health <= 0)
		{
			Explosion.Play();			//Animacja eksplozji
			audioSource.clip = Boom;
			audioSource.PlayOneShot(Boom);

			GameObject thePlayer = GameObject.Find("ThePlayer");		//Znajdź skrypt ShipGUI i dolicz punkty
			ShipGui shipGui = thePlayer.GetComponent<ShipGui>();
			shipGui.Score += Points;

			if (IfDest)					//Sprawdź czy zniszczyć, czy podzielić na mniejsze
			{
				Destroy(gameObject, 1);
			}
			else
			{
				Divide(MeteorChild);
			}
			Destroy(gameObject, 1);
			Health = 999;				//Życie ustawiam na 999 co by w czasie animacji zniszczenia nie zdążył odpalić kolejnych animacji nim obiekt zniknie
		}
	}

	public void Divide(GameObject _meteorchild)
	{

		//rand = Random.Range(1, 3); //choose number of meteor
		rand = 1;
		int _x = (int)gameObject.transform.position.x;
		int _y = (int)gameObject.transform.position.y;
		int _z = (int)gameObject.transform.position.z;

		switch (rand) //Switch which select type of meteor
		{
			case 1:
				{
					for (int i = 0; i < 2; i++)
					{
						Instantiate(_meteorchild, new Vector3(_x+(i*100),_y+(i*100),_z+(i*100)), Quaternion.identity); //create object
					}
					break;
				}
		}
	}
}
