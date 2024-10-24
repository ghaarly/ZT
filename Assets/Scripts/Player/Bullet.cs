using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 10f;
    [SerializeField] public float bulletLife = 2f;
    [SerializeField] float lifeTime;
    public int attack = 10;
    void OnEnable()
    {
        lifeTime =bulletLife;
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0 )
        {
            gameObject.SetActive(false);    
        }
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("La bala chocó con " + other.name);
        IDamage damage = other.GetComponent<IDamage>();
        if (damage != null)
        {
            damage.DoDamage(attack);
        }
    }
}
