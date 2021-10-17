using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour {

	public Transform firePoint;
	public int damage = 40;
	public LineRenderer lineRenderer;

	public LayerMask layer;
	// Update is called once per frame
	void Update () {
		Shoot();
	}

	public void Shoot()
    {
		RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, layer);

		if (hitInfo)
		{
			/*
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}
			*/
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
		}
		else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}
	}
		
}
