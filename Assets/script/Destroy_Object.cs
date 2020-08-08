using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Object : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> walls = new List<GameObject>();
    public List<GameObject> floors = new List<GameObject>();
    public List<GameObject> Background_floor = new List<GameObject>();

    int floorCount = 11;
    
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Spawner>().Destroyfloor.Count == floorCount)
        {
            foreach(GameObject obj in floors)
            {
                Destroy(obj);
            }
            floors.Clear();

            foreach (GameObject obj in walls)
            {
                Destroy(obj);
            }
            walls.Clear();
            foreach (GameObject obj in Background_floor)
            {
                Destroy(obj);
            }
            Background_floor.Clear();
        }
        if(floors.Count == 0)
        {

            foreach (GameObject obj in GetComponent<Spawner>().Destroyfloor)
            {
                floors.Add(obj);
            }
            foreach (GameObject obj in GetComponent<Spawner>().DestroyWall)
            {
                walls.Add(obj);
            }
            foreach (GameObject obj in GetComponent<Background_Spawner>().Destroy_background_floor)
            {
                Background_floor.Add(obj);
            }
            GetComponent<Spawner>().Destroyfloor.Clear();
            GetComponent<Spawner>().DestroyWall.Clear();
            GetComponent<Background_Spawner>().Destroy_background_floor.Clear();
        }
    }
}
