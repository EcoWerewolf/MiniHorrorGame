using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; 
    public int damage =  25;
    public LineRenderer lineRenderer;
    private Camera cam;
    private Vector3 worldPosition;

    void Start() 
    {
        cam = Camera.main;
    }

    void Update() {

         var mousePos = Input.mousePosition;
    mousePos.z = Camera.main.nearClipPlane;
    worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    Debug.DrawLine(firePoint.position, worldPosition);
    
     if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }

    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, worldPosition);
        
        if (hitInfo)
        {
            EnemyPatrol enemy = hitInfo.transform.GetComponent<EnemyPatrol>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0,firePoint.position);
            lineRenderer.SetPosition(1,hitInfo.point);
        } else 
        {
            lineRenderer.SetPosition(0,firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 200);
        }

        lineRenderer.enabled = true;
        yield return(0.0f); 
    }
}
