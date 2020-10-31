using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    public Transform[] lanes;
    public int startLane = 0;
    public float deltaMoveTime;
    public int lives;
    public Text text;
    public SpawnEnemy enemys;

    private int currentLane;
    private int score;

	// Use this for initialization
	void Start () {
        currentLane = startLane;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentLane++;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentLane--;
        }

        if (currentLane < 0) currentLane = 0;
        else if (currentLane > lanes.Length - 1) currentLane = lanes.Length - 1;
        
        gameObject.transform.position = new Vector3(Vector3.MoveTowards(gameObject.transform.position, lanes[currentLane].position, deltaMoveTime/Time.deltaTime).x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MoveEnemy>() != null)
        {
            //gameObject.GetComponent<Animator>().Play("hit");
            GameObject.Destroy(other.gameObject);
            lives--;
            text.text = "Score: " + score + "\nLives: " + lives;
            if(lives <= 0)
            {
                text.text = "GAME OVER";
                enemys.StopAllEnemys();
            }
        }
    }
}
