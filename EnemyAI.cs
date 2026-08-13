/*//using System.Collections;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> points;
    public int nextID=0;
    int idChangeValue = 1;
    public float speed;
    private void Reset()
    {
     Init();
    }
    private void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1");p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");p2.transform.SetParent(waypoints.transform);p2.transform.position = root.transform.position;
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
    private void Update()
    {
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        Transform goalPoint= points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-4, 4, 4);
        else
            transform.localScale = new Vector3(4, 4, 4);

        transform.position=Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }

    }
}
*/
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    //public Collider2D top;
    // public Collider2D bottom;
    // public GameObject eny;
    public int score = 0; // Current score
    //public int highScore; // High score
    public UI snakeUI1;
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed;

    private void Start()
    {
        if (points == null || points.Count == 0)
        {
            Init();
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider = top)
        {

        }
        else
        {

        }
    }*/
    private void Init()
    {
         
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            Debug.LogError("BoxCollider2D component is missing. Please add it to the GameObject.");
            return;
        }
        collider.isTrigger = true;

        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);

        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;

        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        points = new List<Transform> { p1.transform, p2.transform };
    }

    private void Update()
    {
        MoveToNextPoint();
         
    }

    void MoveToNextPoint()
    {
         
        if (points == null || points.Count == 0)
        {
            Debug.LogError("Points list is not initialized or empty.");
            return;
        }

        Transform goalPoint = points[nextID];
        if (goalPoint == null)
        {
            Debug.LogError("Goal point is null. Check the 'points' list for missing elements.");
            return;
        }

        if (goalPoint.position.x > transform.position.x)
            transform.localScale = new Vector3(-4, 4, 4);
        else
            transform.localScale = new Vector3(4, 4, 4);

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
           // AudioManager34.instance.PlaySFX("movingenemy");
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log($"{name} Triggered");
            AudioManager34.instance.PlaySFX("patrolenemy");
            FindObjectOfType<HealthBar>().LoseHealth(100);
            score = 0; // Reset score
            snakeUI1.UpdateScore(score);
            snakeUI1.ShowLosePanel1();
        }
    }
}


