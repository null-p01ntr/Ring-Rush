using UnityEngine;
using UnityEngine.SceneManagement;

public class dog : MonoBehaviour
{
    private float timeToChangeDirection;
    public Rigidbody2D RB2;
    public void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }
    
    public void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
                    ChangeDirection();

        RB2.velocity = transform.up * 2;
    }

    private void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = Random.Range(4f, 8f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Edges" || col.gameObject.tag == "Barrier" || col.gameObject.tag == "Student")
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
