using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 1f;

    [SerializeField] private Transform level_start;
    [SerializeField] private List<Transform> level_partList;
    [SerializeField] private PlayerMovement player;

    private Vector3 lastendPosition;

    
    void Awake()
    {
        lastendPosition = level_start.Find("endPosition").position;
        for(int i = 0; i < 5; i++)
        {
            SpawnLevelPart();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastendPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    void SpawnLevelPart()
    {
        Transform choseLevelpart = level_partList[Random.Range(0, level_partList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(choseLevelpart,lastendPosition);
        lastendPosition = lastLevelPartTransform.Find("endPosition").position;
    }

    Transform SpawnLevelPart(Transform level_part,Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(level_part, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
