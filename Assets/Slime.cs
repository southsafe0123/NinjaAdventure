using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject prefabSlime;
    public MonsterHealth monsterHealth;// Prefab để sinh ra khi slime chết
    // Phương thức để sinh ra 2 bản sao giống y hệt

    private void Update()
    {
        if (monsterHealth.health <= 0)
        {
            SpawnClones();
        }
    }
    public void SpawnClones()
    {
        Debug.Log("Two clones are spawned!");

        Instantiate(prefabSlime, transform.position, Quaternion.identity);
        Instantiate(prefabSlime, transform.position, Quaternion.identity);
        Destroy(this);
    }
}
