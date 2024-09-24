using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject startingRoad;
    [SerializeField] private SpriteRenderer exampleRoad;
    public static GameObject lastRoadSpawned;

    private float spawnOffsetY;

    public List<GameObject> roadsList = new List<GameObject>();

    private void Awake()
    {
        lastRoadSpawned = startingRoad;
        spawnOffsetY = exampleRoad.size.y * 3.5f;
    }
    private void Update()
    {

        if (getUpperBorder() <= spawnPos.transform.position.y)
        {
            int randomRoad = Random.Range(0, roadsList.Count);
            lastRoadSpawned = Instantiate(roadsList[randomRoad],  new Vector3(0,22.38f,0), Quaternion.identity);
        }
    }

    private float getUpperBorder()
    {
        float upperBorder;
        SpriteRenderer lastRoad;
        lastRoad = lastRoadSpawned.transform.Find("LastRoad").GetComponent<SpriteRenderer>();
        upperBorder = lastRoad.transform.position.y + (lastRoad.sprite.bounds.size.y * lastRoad.transform.parent.localScale.y) / 2;
        return upperBorder;
    }

}


