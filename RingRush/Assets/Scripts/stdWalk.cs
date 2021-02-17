using System;
using UnityEngine;

public class stdWalk : MonoBehaviour
{
    public Transform RingTrns;
    public float speed = 1f;
    public int getOff;
    public float distRing;
    public float distStop;

    private Vector3 initPos;
    private Vector3 stopPos;
	private Quaternion stopRot;
	private bool gettingOff;

	Animator anim;
    
    void Start()
    {
        speed = UnityEngine.Random.Range(1f, 2.5f);
        getOff = UnityEngine.Random.Range(0, mainSPWN.STOPCOUNT);
        if (getOff.ToString()==transform.parent.transform.name[0].ToString())
        {
            getOff++;
            if (getOff == mainSPWN.STOPCOUNT)
                getOff = 0;
        }
		gettingOff = false;
		anim =GetComponent<Animator>();
        anim.SetBool("isWalking", false);
        anim.speed = speed+0.5f;
        initPos = gameObject.transform.position;
    }

    void Update()
    {
        //set distance   
        distRing = Vector2.Distance(transform.position, RingTrns.position);
        distStop = Vector2.Distance(transform.position, mainSPWN.stops[getOff].stdSpawner.transform.position);

        // Get Off
        if (getOff == Ring.detectZone() && distStop < 6 || gettingOff)
        {
            gettingOff = true;
            //set student rotation to stop
            if (Ring.detectZone() != 99)
            {
                float AngleRad2 = Mathf.Atan2(mainSPWN.stops[Ring.detectZone()].stdSpawner.transform.position.y - gameObject.transform.position.y, mainSPWN.stops[Ring.detectZone()].stdSpawner.transform.position.x - gameObject.transform.position.x);
                float AngleDeg2 = (180 / Mathf.PI) * AngleRad2;
                stopRot = Quaternion.Euler(0, 0, AngleDeg2 - 90);
            }
            gameObject.transform.rotation = stopRot;
            //student walk to stop
            anim.SetBool("isWalking", true);
            if (Ring.detectZone() != 99)
                stopPos = mainSPWN.stops[Ring.detectZone()].stdSpawner.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, stopPos, speed * Time.deltaTime);
            if (gameObject.transform.position == stopPos)
            {
                Destroy(gameObject); //walk to building
                Score.score++; //add score at drop off
            }
        }
        //Get On
        else if (Ring.detectZone() != 99 && Ring.doors && distRing < 7 && RingTrns.transform.childCount - 1 < 50)
        {
            //set student rotation to ring
            float AngleRad = Mathf.Atan2(RingTrns.position.y - gameObject.transform.position.y, RingTrns.position.x - gameObject.transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
            //student walk to ring
            anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, RingTrns.position, speed * Time.deltaTime);
            if (transform.position == RingTrns.transform.position)
            {
                gameObject.transform.parent = RingTrns;
                gameObject.SetActive(false);
                Score.score++; //add score at pickup
            }
        }
        //Student didn't picked up
        else if (gameObject.transform.position != initPos && Ring.detectZone() == 99 && !gettingOff)
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
        }
        //Idle at Stop
        else 
        { 
            anim.SetBool("isWalking", false);
            //set student rotation to ring
            float AngleRad = Mathf.Atan2(RingTrns.position.y - gameObject.transform.position.y, RingTrns.position.x - gameObject.transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
        }     
    }
    void OnTriggerEnter2D(Collider2D col)
    {//detect student get on
        if (col.gameObject.name == "Ring" && Ring.doors)
        {
            gameObject.transform.parent = col.gameObject.transform;
            gameObject.SetActive(false);
            Score.score++; //add score at pickup
        }
    }
}
