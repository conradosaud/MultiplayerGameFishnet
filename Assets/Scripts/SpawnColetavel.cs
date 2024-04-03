using UnityEngine;
using FishNet.Object;

public class SpawnColetavel : NetworkBehaviour
{

    public float intervaloSpawn = 0.5f;

    public Transform prefabColetavel;
    public Transform areaSpawn;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (base.IsServer)
            Spawnar();

    }


    void Spawnar()
    {
        float areaX = areaSpawn.localScale.x / 2;
        float areaZ = areaSpawn.localScale.z / 2;
        Vector3 localSpawn = new Vector3(Random.Range(-areaX, areaX), prefabColetavel.position.y, Random.Range(-areaZ, areaZ));

        Transform instancia = Instantiate(prefabColetavel, transform);
        instancia.position = localSpawn;

        ServerManager.Spawn(instancia.gameObject);

        Invoke("Spawnar", intervaloSpawn);
    }

}
