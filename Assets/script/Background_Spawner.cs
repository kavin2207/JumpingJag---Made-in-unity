using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> wallFloor = new List<GameObject>();
    public List<GameObject> Destroy_background_floor = new List<GameObject>();
    Vector3 add = new Vector3(0, 1.1f, 0);
    Vector3  nextPosi,prevPosi,prevNightPosi,nextNightPosi,add1;
    public GameObject nightBackground;
    public Transform aim;
    void Start()
    {
        prevPosi = GetComponent<Destroy_Object>().Background_floor[6].transform.position;
        prevNightPosi = nightBackground.transform.position;
        add1 = new Vector3(0, 14f, 0);
    }
    void Update()
    {
        if ((aim.position-GetComponent<Spawner>().player.position).magnitude < 10f)
        {
            night();
        }
    }
    
    public void BackgroundSpawner()
    {
        GameObject wallpaper;
        nextPosi = add + prevPosi;
        int x;
        x = Random.Range(0, 6);
        x = x % 6;
        wallpaper = Instantiate(wallFloor[x], nextPosi, Quaternion.identity);
        GetComponent<Background_Spawner>().Destroy_background_floor.Add(wallpaper);
        prevPosi = nextPosi;
    }

    public void night()
    {
        GameObject nightBack;
        nextNightPosi.y = prevNightPosi.y + add1.y;
       
        nightBack = Instantiate(nightBackground, nextNightPosi, Quaternion.identity);
        
        prevNightPosi = nextNightPosi;
        aim.position = nextNightPosi;
        
    }
}
