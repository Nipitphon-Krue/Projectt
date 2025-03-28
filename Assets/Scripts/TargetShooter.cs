using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    public static Action OnTargetMissed;

    [SerializeField] private Camera cam;

    private void Update()
    {
        if (Timer.GameEnded)
            return;

        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Target target = hit.collider.gameObject.GetComponent<Target>();

            if (target != null)
            {
                target.Hit();
            }
            else
            {
                MissTarget();
            }
        }
        else
        {
            MissTarget();
        }
    }

    private void MissTarget()
    {
        OnTargetMissed?.Invoke();
    }
}
