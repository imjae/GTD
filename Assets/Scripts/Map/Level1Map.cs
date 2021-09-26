using UnityEngine;

class Level1Map : Map
{
    public Level1Map()
    {
        type = MapType.Level1;
        name = "level1";
        respawnPoint = new Vector3(55f, -0.5f, -26.89f);
        wayPoint = new Vector3[4];
    }
}