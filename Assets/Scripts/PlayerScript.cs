using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Transform missile2;
    GameObject player;
    GameObject AI;
    float acceleration;
    float maxSpeed = 10f;
    float missileacceleration;
    float maxMissileSpeed = 40f;
    Vector3 pointerposition;
    Vector3 AIposition;
    GameObject missileObject;
    bool canShoot;
    // Use this for initialization
    void Start () {
        canShoot = true;
        player = GameObject.Find("Player");
        AI = GameObject.Find("AI");
        acceleration = 0.0f;
        pointerposition = new Vector3(25f, 725f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (acceleration < maxSpeed && Input.GetMouseButton(0))
        {
            acceleration += 0.1f;
        }

        if(acceleration> 0 && !Input.GetMouseButton(0))
        {
            acceleration -= 0.1f;
        }

        if (missileacceleration < maxMissileSpeed)
            missileacceleration += 0.4f;

        if (Input.GetMouseButton(0)){
            float x = (60 * Input.mousePosition.x / Screen.width) - 30;
            float z = (24 * Input.mousePosition.y / Screen.height) - 12;
            if (x > 15 && x < 30 && z > -12 && z < 12)
                pointerposition = new Vector3(x, 725, z);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (canShoot)
            {
                AIposition = AI.transform.position;
                Transform clone;
                clone = Instantiate(missile2, player.transform.position, Quaternion.identity);
                canShoot = false;
                StartCoroutine(Wait());
            }
        }

        if (missileObject = GameObject.Find("missile2(Clone)"))
        {
            missileObject.transform.position = Vector3.MoveTowards(missileObject.transform.position, AIposition, missileacceleration * Time.deltaTime);
            missileObject.transform.LookAt(AIposition);

            if(Vector3.Distance(AI.transform.position, missileObject.transform.position) < 1)
            {
                WinCondition.win = 1;
            }


            if (missileObject.transform.position == AIposition)
            {
                Destroy(missileObject);
                missileacceleration = 0;
            }
        }

        MovePlayer();
    }

    void MovePlayer()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, pointerposition, acceleration*Time.deltaTime);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        canShoot = true;
        
    }
}
