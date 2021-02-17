using UnityEngine;

public class ProjectilePool : Pool
{
	private void Start()
	{
		if (!(sourceObject is Projectile))
		{
			Debug.LogError($"ProjectilePool {gameObject.name} has a prefab that is not a projectile", this);
			enabled = false;
		}
	}

	public Projectile GetPooledProjectile() => base.GetPooledObject() as Projectile;

	public override void ReturnPooledObject(Poolable returningObject)
	{
		returningObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

		base.ReturnPooledObject(returningObject);
	}
}
