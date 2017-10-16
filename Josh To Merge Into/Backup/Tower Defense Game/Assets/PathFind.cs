using UnityEngine;
using System.Collections;
using System;

public class PathFind : MonoBehaviour {

    public GameObject[] points;
    public GameObject test;
    Vector2 aim, current, move;
    int currentPoint = 0;
    Rigidbody2D rb;

    int direction = 1;

    [Range(0.0f, 25.0f)]
    public float speed = 50.0f;

	// Use this for initialization
	void Start ()
    {
        test = GameObject.FindGameObjectWithTag("WaveManager");
        points = test.GetComponent<WaveManager>().GetPathPoints();

        //transform.LookAt(new Vector3(points[currentPoint].transform.position.x,0, points[currentPoint].transform.position.z), Vector3.back);
        Vector3 dir = points[currentPoint].transform.position - transform.position;
        dir = points[currentPoint].transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = new Quaternion(0, 0, angle, 0);

    }

    // Update is called once per frame
    void Update () {
    }

    void FixedUpdate ()
    {
        Quaternion rotation = Quaternion.LookRotation
     (points[currentPoint].transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        float previousDistance = Mathf.Abs(points[currentPoint].transform.position.x - transform.position.x) + Mathf.Abs(points[currentPoint].transform.position.y - transform.position.y) + Mathf.Abs(points[currentPoint].transform.position.z - transform.position.z);
        //transform.LookAt(new Vector3(points[currentPoint].transform.position.x,0, points[currentPoint].transform.position.z), Vector3.back);

        //            Quaternion rotation = Quaternion.LookRotation
        //         (points[currentPoint].transform.position - transform.position, transform.TransformDirection(Vector3.up));
        //           transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w); 

        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        float newDistance = Mathf.Abs(points[currentPoint].transform.position.x - transform.position.x) + Mathf.Abs(points[currentPoint].transform.position.y - transform.position.y) + Mathf.Abs(points[currentPoint].transform.position.z - transform.position.z);

        if (newDistance > previousDistance)
        {
            direction = -direction;
            transform.Translate(direction * speed * Time.deltaTime * 2, 0, 0);
        }

        if (points[currentPoint].transform.position.y > transform.position.y)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject == points[currentPoint])
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        currentPoint++;
        //transform.LookAt(new Vector3(points[currentPoint].transform.position.x, 0, points[currentPoint].transform.position.z));
        Quaternion rotation = Quaternion.LookRotation
             (points[currentPoint].transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
