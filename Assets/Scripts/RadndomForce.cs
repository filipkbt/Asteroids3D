using UnityEngine;

public class RadndomForce : MonoBehaviour {

	#region Public Variables
	public Rigidbody rb;
    public float min;
    public float max;
	#endregion

	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max), ForceMode.Impulse);
    }
	
	void Update () {}
}
