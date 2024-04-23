using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitParticles;
    private Vector3 shootDirection;
    private GameObject player;

    [SerializeField] private float speed = 10f;
    public void Setup(Vector3 shootDir, GameObject player)
    {
        this.shootDirection = shootDir;
        this.player = player;   
    }

    void Update()
    {
        transform.position += shootDirection * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player && other.gameObject != gameObject)
        {
            if(other.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                GameObject hitImpact = Instantiate(hitParticles, transform.position, Quaternion.identity);
                hitImpact.transform.localEulerAngles = new Vector3(0, 0, 90);
            }
           
            Destroy(gameObject);
        }
    }
}
