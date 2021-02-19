using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : Poolable
{
	Rigidbody r;
	public float projectileSpeed;
	//[System.NonSerialized]
	public float damage;

	private void Awake()
	{
		r = GetComponent<Rigidbody>();
	}

	public void Fire(float _damage)
	{
		r.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
		damage = _damage;
		Invoke("RePool", 3f);
		Debug.DrawRay(transform.position, transform.forward, Color.white, 0.3f);
	}

	void RePool()
	{
		r.velocity = Vector3.zero;
		r.rotation = Quaternion.identity;
		r.position = Vector3.zero;
		ReturnToPool();
	}
}
