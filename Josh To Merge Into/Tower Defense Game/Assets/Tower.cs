using UnityEngine;
using System.Collections;
using System.Linq;

public class Tower : MonoBehaviour
{

    public float speed = 1f;

    [Range(0.0f, 5.0f)]
    public float sight = 2f;
    public GameObject bullet;
    public float fireDelay = 1;
    public float bulletForce = 1;
    public bool canFire;
    public float Timer = 2;

    public float rotSpeed = 90f;

    GameObject target = null;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var objects = GameObject.FindGameObjectsWithTag("Enemy");
        if (!objects.Any())
            return;

        var distances = objects.Select(s => Vector3.Distance(transform.position, s.transform.position)).ToArray();
        var first = distances.First();
        var index = 0;
        var index1 = 0;
        foreach (var distance in distances)
        {
            if (distance < first)
            {
                index1 = index;
                break;
            }
            index++;
        }

        if (Vector3.Distance(objects[index1].transform.position, transform.position) < sight)
        {
            target = objects[index1];
            if (target == null)
                return;

            //          var p1 = transform.position;
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            Vector3 dir = target.transform.position - transform.position;
            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle - 170);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

            if (canFire == true)
            {
                StartCoroutine(FireBullets());
            }
            else
            {
                StopCoroutine(FireBullets());
            }
        }
    }

    IEnumerator FireBullets()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(-newBullet.transform.right * bulletForce, ForceMode2D.Impulse);
            Destroy(newBullet, 3);
            Timer = 1f;
            yield return new WaitForSeconds(fireDelay);
        }        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sight);
    }
}
