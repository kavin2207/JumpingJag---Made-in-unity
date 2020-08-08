using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [HideInInspector]
    public List<GameObject> DestroyWall = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> Destroyfloor = new List<GameObject>();
    public Vector3 add;
    Vector3 nextFloorPosi, prevFloorPosi, nextLeftWallPosi, nextRightWallPosi, prevLeftWallPosi, prevRightWallPosi;
    public GameObject wall_Spawn, floor_Spawn;
    public Transform player;

    float dis;


    void Start()
    {
        //add = new Vector3(0, 1.3f, 0);
        prevFloorPosi = GetComponent<Destroy_Object>().floors[8].transform.position;
        prevLeftWallPosi = GetComponent<Destroy_Object>().walls[8].transform.position;
        prevRightWallPosi = GetComponent<Destroy_Object>().walls[11].transform.position;
        //dis = (player.position - prevFloorPosi).magnitude;
        //Debug.Log(dis);

    }

    // Update is called once per frame
    void Update()
    {
        if ((prevFloorPosi - player.position).magnitude < 8)
        {
            spawn_Floor();
            spawn_Wall();
            GetComponent<Background_Spawner>().BackgroundSpawner();
            
        }
    }

    void spawn_Floor()
    {
        GameObject floorSpawn;

        nextFloorPosi = prevFloorPosi + add;

        floorSpawn = Instantiate(floor_Spawn, nextFloorPosi, Quaternion.identity);

        prevFloorPosi = nextFloorPosi;
        Destroyfloor.Add(floorSpawn);

    }

    void spawn_Wall()
    {
        GameObject spawnWall1, spawnWall2;
        int x;
        x = Random.Range(0, 8);
        x = x % 4;
        switch (x)
        {
            case 0:
                nextLeftWallPosi = prevLeftWallPosi + add;
                nextRightWallPosi = prevRightWallPosi + add;
                spawnWall1 = Instantiate(wall_Spawn, nextLeftWallPosi, Quaternion.identity);
                DestroyWall.Add(spawnWall1);
                prevLeftWallPosi = nextLeftWallPosi;
                prevRightWallPosi = nextRightWallPosi;
                break;

            case 1:
                nextLeftWallPosi = prevLeftWallPosi + add;
                nextRightWallPosi = prevRightWallPosi + add;
                spawnWall2 = Instantiate(wall_Spawn, nextRightWallPosi, Quaternion.identity);
                DestroyWall.Add(spawnWall2);
                prevRightWallPosi = nextRightWallPosi;
                prevLeftWallPosi = nextLeftWallPosi;
                break;

            case 2:
                nextLeftWallPosi = prevLeftWallPosi + add;
                nextRightWallPosi = prevRightWallPosi + add;

                spawnWall1 = Instantiate(wall_Spawn, nextLeftWallPosi, Quaternion.identity);
                DestroyWall.Add(spawnWall1);

                spawnWall2 = Instantiate(wall_Spawn, nextRightWallPosi, Quaternion.identity);
                DestroyWall.Add(spawnWall2);
                prevRightWallPosi = nextRightWallPosi;
                prevLeftWallPosi = nextLeftWallPosi;
                break;
            default:
                nextLeftWallPosi = prevLeftWallPosi + add;
                nextRightWallPosi = prevRightWallPosi + add;
                prevRightWallPosi = nextRightWallPosi;
                prevLeftWallPosi = nextLeftWallPosi;
                break;

        }
    }
}
