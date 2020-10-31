using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    
    public double timeout;
    public GameObject enemy;
    public Transform[] lanes;
    public Transform spawnPos;
    public Transform diePos;
    
    private double currentTimeout;
    private List<MoveEnemy> enemys;
    private bool stop;

	// Use this for initialization
	void Start () {
        currentTimeout = 0;
        enemys = new List<MoveEnemy>();
        stop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            if (currentTimeout >= timeout)
            {
                spawnEnemy();
                currentTimeout = 0;
            }
            currentTimeout += Time.deltaTime;
        }
	}

    void spawnEnemy()
    {
        GameObject newEnemy = GameObject.Instantiate(enemy);
        int lane = Random.Range(0, lanes.Length);
        Vector3 pos = new Vector3(lanes[lane].position.x, newEnemy.transform.position.y, spawnPos.position.z);
        newEnemy.transform.position = pos;
        MoveEnemy mE = newEnemy.GetComponent<MoveEnemy>();
        if (mE != null)
        {
            mE.diePos = diePos;
            enemys.Add(mE);
        }
    }

    public void StopAllEnemys()
    {
        stop = true;
        foreach(MoveEnemy ene in enemys)
        {
            ene.stop = true;
        }
    }
}
