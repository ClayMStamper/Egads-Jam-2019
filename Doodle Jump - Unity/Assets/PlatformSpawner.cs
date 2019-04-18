using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject player;

    public float numPlatforms = 10;

    private float lastHeight = 0;
    public float spawnDistance = 4;
    
    private void Start() {
        player.GetComponent<Player>().OnJumped += CheckSpawn;
        Spawn();
    }

    public void CheckSpawn() {
        print("pos: " + player.transform.position.y);
        print("lastHeight: " + lastHeight);

        if (player.transform.position.y > lastHeight + spawnDistance) {
            Spawn();
        }
    }

    void Spawn() {
        
        print("spawned");
        
        lastHeight = player.transform.position.y;

        for (int i = 0; i < numPlatforms; i++) {

            float x = Random.Range(-4, 4);
            float y = Random.Range(player.transform.position.y + 5, player.transform.position.y  + 10);
            Vector3 platformPos = new Vector3(x,y);
            Instantiate(platformPrefab, platformPos, Quaternion.identity);
        }
        
    }
}
