using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    public LayerMask targetLayer; // Specify the target layer

    [SerializeField] private GameObject triggeredLights;

    private LineRenderer laserLine;
    private float fireTimer;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        triggeredLights.SetActive(false);
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && fireTimer > fireRate)
        {
            fireTimer = 0f;
            StartCoroutine(ShootLaser());
        }
    }

    private IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, laserOrigin.position);

        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 0));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange, targetLayer))
        {
            // Check if the object is on the target layer
            laserLine.SetPosition(1, hit.point);
            //Instead of destroy turn all lights on
            //Destroy(hit.collider.gameObject); // Destroy the object hit by the laser if it's on the target layer
            triggeredLights.SetActive(true);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        }

        yield return new WaitForSeconds(laserDuration);

        laserLine.enabled = false;
    }
}


