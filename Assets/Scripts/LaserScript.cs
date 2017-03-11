using UnityEngine;

public class LaserScript : MonoBehaviour
{
	#region Public Variables
	public Rigidbody rb;
    public float speed;
    public float damage;
    public float autodest;
	#endregion

	// Use this for initialization
	void Start()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, autodest);
    }
}
