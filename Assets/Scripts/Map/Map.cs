using UnityEngine;
public enum MapType
{
    Level1
}

abstract class Map
{
    protected MapType type;
    protected string name;
    protected Vector3 respawnPoint;
    protected Vector3[] wayPoint;
}