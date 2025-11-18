using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 4f;
    public float minHeight = -2.6f;
    public float maxHeight = 2.6f;

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),2.5f, spawnRate); // sau 1s va moi 1s se call Spawn()
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));  
    }

    private void Spawn()
    {
        //rotation = (0,0,0) identity
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); //tao ra mot clone cua gameobject trong game
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); //Vector.up - (0,1)
    }
}
