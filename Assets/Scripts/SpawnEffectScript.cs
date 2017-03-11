using UnityEngine;

public class SpawnEffectScript : MonoBehaviour {
	#region Public Variables
	public ParticleSystem Effect;
	public GameObject Spawn;
	#endregion

	void Start () {}
	
	void Update () {
		if(!Effect.IsAlive())
		{
			Instantiate(Spawn, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
