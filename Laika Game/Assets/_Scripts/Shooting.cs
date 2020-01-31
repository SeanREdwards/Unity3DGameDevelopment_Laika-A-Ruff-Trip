using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public int bulletForce;
    private GameObject temp;
    public GameObject spawnPoint, endPoint;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f,5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent != null)
        {
            if (transform.parent.parent.transform.gameObject.name == "Guide")
            {
                Destroy(temp);
                StopAllCoroutines();
            }
        }
    }

    void Shoot()
    {
        StartCoroutine(ShootingSequence());
    }

    IEnumerator ShootingSequence()
    {

        temp = Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
        temp.transform.parent = this.transform;


        yield return new WaitForSeconds(2f);
        temp.transform.parent = null;
        direction = (endPoint.transform.position - spawnPoint.transform.position).normalized;

        temp.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletForce);

        yield return new WaitForSeconds(2f);
        Destroy(temp);

        yield return null;
    }

    void ShootFunction()
    {
    }

    void DeleteBullet()
    {
    }

}
