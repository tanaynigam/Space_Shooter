using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

    public Transform missile;
    GameObject AI;
    GameObject player;
    float acceleration;
    float maxSpeed = 10f;
    bool motion;
    float missileacceleration;
    float maxMissileSpeed = 40f;
    Vector3 new_position;
    Vector3 playerposition;
    GameObject missileObject;

	// Use this for initialization
	void Start () {
        missileacceleration = 0.0f;
        acceleration = 0.0f;
        AI = GameObject.Find("AI");
        player = GameObject.Find("Player");
        new_position = new Vector3(Random.Range(-30.0f, -15.0f), 725, Random.Range(-12.0f, 12.0f));
        motion = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (acceleration < maxSpeed)
            acceleration += 0.1f;

        if (missileacceleration < maxMissileSpeed)
            missileacceleration += 0.4f;

        if(motion == true)
        {
            MoveAI();
        }else
        {
            new_position = new Vector3(Random.Range(-30.0f, -15.0f), 725, Random.Range(-12.0f, 12.0f));
        }

        if (missileObject = GameObject.Find("missile(Clone)")){
            missileObject.transform.position = Vector3.MoveTowards(missileObject.transform.position, playerposition, missileacceleration * Time.deltaTime);
            missileObject.transform.LookAt(playerposition);

            if (Vector3.Distance(player.transform.position, missileObject.transform.position) < 1)
            {
                WinCondition.win = -1;
            }

            if (missileObject.transform.position == playerposition)
            {
                Destroy(missileObject);
                missileacceleration = 0;
            }
        }
    }

    void MoveAI()
    {
        AI.transform.position = Vector3.MoveTowards(AI.transform.position, new_position, acceleration * Time.deltaTime);
        if(AI.transform.position == new_position)
        {
            acceleration = 0;
            motion = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        playerposition = player.transform.position;
        AIShoot();
        motion = true;
    }

    void AIShoot()
    {
        Transform clone;
        clone = Instantiate(missile, AI.transform.position, Quaternion.identity);        
    }
}
