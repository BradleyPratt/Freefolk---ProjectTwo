using UnityEngine;
using System.Collections;
using System;

public class PathFind : MonoBehaviour {

    public GameObject[] points;
    public GameObject test;
    Vector2 aim, current, move;
    int currentPoint = 0;
    Rigidbody2D rb;

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
        int direction;
        Quaternion rotation = Quaternion.LookRotation
     (points[currentPoint].transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        //transform.LookAt(new Vector3(points[currentPoint].transform.position.x,0, points[currentPoint].transform.position.z), Vector3.back);

        //            Quaternion rotation = Quaternion.LookRotation
        //         (points[currentPoint].transform.position - transform.position, transform.TransformDirection(Vector3.up));
        //           transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w); 
        if ((transform.position.x < points[currentPoint].transform.position.x) || (transform.position.y > points[currentPoint].transform.position.y))
        {
            direction = -1;
        } else
        {
            direction = 1;
        }
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "PathEnd")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject == points[currentPoint])
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
