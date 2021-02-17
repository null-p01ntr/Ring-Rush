using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class mainSPWN : MonoBehaviour
{
    //STOPS
    static public int STOPCOUNT=10;//INCREMENT IF STOP ADDED
    public struct Stops
    {
        public int stdDensMin;
        public int stdDensMax;
        public float spwnX_Max;
        public float spwnX_Min;
        public float spwnY_Max;
        public float spwnY_Min;
        public GameObject stdSpawner;
    }
    static public Stops[] stops = new Stops[STOPCOUNT];
    public GameObject[] spawners;
    //STUDENT SPAWN
    public GameObject[] std;
    public int stdType;
    public bool END = false;
    int i = 0;
    //DOG SPAWN
    public GameObject[] dog;
    public int dogType;
    static public int dogCount;
    public bool dogEND = false;
    //DELAY
    bool wait=false;

    void Start()
    {
        //STOP DATABASE
        //ust kapi
        stops[0].stdDensMin = 15;
        stops[0].stdDensMax = 22;
        stops[0].stdSpawner = spawners[0];
        stops[0].spwnX_Max = 0.5f;
        stops[0].spwnX_Min = -0.7f;
        stops[0].spwnY_Max = 2.5f;
        stops[0].spwnY_Min = -2.5f;
        //muh alt
        stops[1].stdDensMin = 15;
        stops[1].stdDensMax = 22;
        stops[1].stdSpawner = spawners[1];
        stops[1].spwnX_Max = 2f;
        stops[1].spwnX_Min = -1.6f;
        stops[1].spwnY_Max = 2f;
        stops[1].spwnY_Min = -2f;
        //alt kapi
        stops[2].stdDensMin = 7;
        stops[2].stdDensMax = 10;
        stops[2].stdSpawner = spawners[2];
        stops[2].spwnX_Max = 1f;
        stops[2].spwnX_Min = -1f;
        stops[2].spwnY_Max = 1f;
        stops[2].spwnY_Min = -1f;
        //hali saha
        stops[3].stdDensMin = 15;
        stops[3].stdDensMax = 22;
        stops[3].stdSpawner = spawners[3];
        stops[3].spwnX_Max = 4f;
        stops[3].spwnX_Min = -0.5f;
        stops[3].spwnY_Max = 1f;
        stops[3].spwnY_Min = -1f;
        //festival alani
        stops[4].stdDensMin = 5;
        stops[4].stdDensMax = 10;
        stops[4].stdSpawner = spawners[4];
        stops[4].spwnX_Max = 1f;
        stops[4].spwnX_Min = -1f;
        stops[4].spwnY_Max = 1f;
        stops[4].spwnY_Min = -1f;
        //gsf arka
        stops[5].stdDensMin = 12;
        stops[5].stdDensMax = 18;
        stops[5].stdSpawner = spawners[5];
        stops[5].spwnX_Max = 2f;
        stops[5].spwnX_Min = -2f;
        stops[5].spwnY_Max = 1f;
        stops[5].spwnY_Min = 0f;
        //gsf sosyal
        stops[6].stdDensMin = 15;
        stops[6].stdDensMax = 20;
        stops[6].stdSpawner = spawners[6];
        stops[6].spwnX_Max = 2f;
        stops[6].spwnX_Min = -2f;
        stops[6].spwnY_Max = 1f;
        stops[6].spwnY_Min = 0f;
        //rektorluk
        stops[7].stdDensMin = 23;
        stops[7].stdDensMax = 28;
        stops[7].stdSpawner = spawners[7];
        stops[7].spwnX_Max = 3f;
        stops[7].spwnX_Min = -3f;
        stops[7].spwnY_Max = 1f;
        stops[7].spwnY_Min = 0f;
        //yokus alt
        stops[8].stdDensMin = 18;
        stops[8].stdDensMax = 20;
        stops[8].stdSpawner = spawners[8];
        stops[8].spwnX_Max = 2f;
        stops[8].spwnX_Min = -2f;
        stops[8].spwnY_Max = 1f;
        stops[8].spwnY_Min = 0f;
		//gsf on
		stops[9].stdDensMin = 10;
		stops[9].stdDensMax = 15;
		stops[9].stdSpawner = spawners[9];
		stops[9].spwnX_Max = 1f;
		stops[9].spwnX_Min = -1f;
		stops[9].spwnY_Max = 1f;
		stops[9].spwnY_Min = -1f;


		dogCount =0;
        SpawnDoggo();

        for (int n=0; n < STOPCOUNT-1; n++)
            SpawnSTD(n);
        wait = true;
    }
    void Update()
    {
        if (wait)
            StartCoroutine(ContinousSpawn());
    }

    private void SpawnSTD(int ID)
    {
		END = false;

		while (!END)
		{
			float spawnX = Random.Range(stops[ID].spwnX_Min, stops[ID].spwnX_Max);
			float spawnY = Random.Range(stops[ID].spwnY_Min, stops[ID].spwnY_Max);
			stdType = Random.Range(0, std.Length);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

			Instantiate(std[stdType], spawnPos + stops[ID].stdSpawner.transform.TransformPoint(0, 0, 0), stops[ID].stdSpawner.transform.rotation).transform.parent = stops[ID].stdSpawner.transform;

			if (stops[ID].stdSpawner.transform.childCount >= Random.Range(stops[ID].stdDensMin, stops[ID].stdDensMax))//std density
				END = true;
		}
    }

    private void SpawnDoggo()
    {
        while (!dogEND)
        {
            float spawnX = Random.Range(-10f, 65f);
            float spawnY = Random.Range(0f, 35f);
            dogType = Random.Range(0, dog.Length);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

            Instantiate(dog[dogType], spawnPos + transform.TransformPoint(0, 0, -3), transform.rotation).transform.parent = transform;

            dogCount++;

            if (dogCount == 30)//dog count
                dogEND = true;
        }
    }

    IEnumerator ContinousSpawn()
    {
        wait = false;
		if (stops[i].stdSpawner.transform.childCount <= stops[i].stdDensMin && Ring.detectZone() != i)
		{
			yield return new WaitForSeconds(10);
			SpawnSTD(i);
		}

		i++;
		if (i == STOPCOUNT)
            i = 0;

		wait = true;
    }
}
