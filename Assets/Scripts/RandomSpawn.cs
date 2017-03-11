using System;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

	#region Public Variables
	public GameObject[] RandomObject;
	public GameObject RegularObject;
	public int RegularObjectTime;
	public int RandomObjectTime;
	#endregion

	#region Private Variables
	private float Radius;
	private DateTime regularObjectLastInstantite = DateTime.MinValue;
	private DateTime randomObjectLastInstantite = DateTime.MinValue;
	private int rand;
	#endregion

	void Start()
	{
		GameObject sphere = GameObject.Find("Glass");
		this.Radius = sphere.transform.localScale.x;
	}

	void Update()
	{
		if (DateTime.Now.Subtract(regularObjectLastInstantite).TotalMilliseconds > RegularObjectTime)
		{
			RandSpawn(RegularObject);
			regularObjectLastInstantite = DateTime.Now;
		}
		if (DateTime.Now.Subtract(randomObjectLastInstantite).TotalMilliseconds > RandomObjectTime)
		{
			rand = UnityEngine.Random.Range(0, RandomObject.Length);
			RandSpawn(RandomObject[rand]);
			randomObjectLastInstantite = DateTime.Now;
		}

	}

	public void RandSpawn(GameObject create)
	{
		Instantiate(create, UnityEngine.Random.insideUnitSphere * Radius, transform.rotation);
	}

}
