using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] public Transform posGun;
    [SerializeField] public Transform cam;
    [SerializeField] public LayerMask player;
    RaycastHit hit;
    
    void Update()
    {
        Debug.DrawRay(cam.position, cam.forward * 10f, Color.green);
        Debug.DrawRay(posGun.position, posGun.forward * 10f, Color.red);
        
        if (Input.GetMouseButtonDown(0))
	    {
            Vector3 direction = cam.TransformDirection(new Vector3(0,0,1));

            GameObject bulletObj = ObjectPoolingManager.Instance.GetBullet();

            bulletObj.transform.position = posGun.position;
            if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, ~player))
                {
                    bulletObj.transform.LookAt(hit.point);
                }
            else
            {
                Vector3 dir = cam.position + cam.forward * 10f;
          
            }
           
	    }
    }

    
}
