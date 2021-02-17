using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ring : MonoBehaviour {

	Rigidbody2D RB2;
    static public int health;
   
    [SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;

    bool go = false;
    bool rev = false;
    bool left = false;
    bool right = false;
    public GameObject doorButton;
    public Sprite doorOpen;
    public Sprite doorClosed;
    static public bool doors = false;

	static public bool ea = false;


	public GameObject GameOver;

    void Start ()
    {
        RB2 = GetComponent<Rigidbody2D>();
        health = 100;
        GameOver.SetActive(false);
        Pause.paused=false;
    }
	private void Update()
	{
		//door mechanism
		if (Input.GetKeyDown("c"))
			doors = !doors;
		//update door status at UI
		if (doors)
			doorButton.GetComponent<Image>().sprite = doorOpen;
		else doorButton.GetComponent<Image>().sprite = doorClosed;

		//activate students will get off
		if (detectZone() != 99 && doors)
		{
			for (int i = 1; i < transform.childCount; i++)
			{
				if (detectZone() == transform.GetChild(i).GetComponent<stdWalk>().getOff)
				{
					transform.GetChild(i).gameObject.SetActive(true);
					transform.GetChild(i).GetComponent<Collider2D>().enabled = false; //remove their collider to ignore the collision with each other
					transform.GetChild(i).parent = null;
				}
			}
		}

		if (transform.childCount - 1 >= 50)
		{
			Capacity.capacity.color = Color.red;
			doors = false; //close the doors if capacity full
		}
		else Capacity.capacity.color = Color.green;

		if (Null_p0inter.easteregg && doors)
		{
			ea = true;
		}
	}
	void FixedUpdate ()
    {
        //vertical movement
        speed = Input.GetAxis("Vertical") * accelerationPower; //keyboard input
        //update with UI button
        if (go)
            speed = accelerationPower;
        else if (rev)
            speed = -accelerationPower;

        if (!doors)//dont move if door is open
            RB2.AddRelativeForce(Vector2.up * speed);

        //horizontal movement
        steeringAmount = -Input.GetAxis("Horizontal"); //keyboard input
		//update with UI button
		if (left)
            steeringAmount = steeringPower;
        else if (right)
            steeringAmount = -steeringPower;
		
        direction = Mathf.Sign(Vector2.Dot(RB2.velocity, RB2.GetRelativeVector(Vector2.up)));
        RB2.rotation += steeringAmount * steeringPower * RB2.velocity.magnitude * direction;
        RB2.AddRelativeForce ( - Vector2.right * RB2.velocity.magnitude * steeringAmount / 2);
    }

    static public int detectZone()//returns current stop ID
    {
        if (ustSpawner.inZone)
            return 0; 
        else if (muhAltSpawner.inZone)
            return 1; 
        else if (altKapiSpawner.inZone)
            return 2;
        else if (haliSahaSpawner.inZone)
            return 3;
        else if (festivalSpawner.inZone)
            return 4;
        else if (gsfArkaSpawner.inZone)
            return 5;
        else if (gsfSosyalSpawner.inZone)
            return 6;
        else if (rektorlukSpawner.inZone)
            return 7;
        else if (yokusAltSpawner.inZone)
            return 8;
		else if (gsfOnSpawner.inZone)
			return 9;
		else  return 99;  //not in zone
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Edges")
        {
            health--;
            if (health == 0)
                GameOver.SetActive(true);
        }

        if (col.gameObject.tag == "Dog" && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 7)
            GameOver.SetActive(true);
    }
	//UI button implementations
	public void Forward(bool _go)
    {
        go = _go;
    }
    public void Reverse(bool _rev)
    {
        rev = _rev;
    }
    public void Left(bool _left)
    {
        left = _left;
    }
    public void Right(bool _right)
    {
        right = _right;
    }
    public void Doors()
    {
        doors = !doors;
    }
}
