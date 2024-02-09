using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSeeder : MonoBehaviour
{
    public List<GameObject> Flowers;
    public int count = 200;
    public float radius = 50f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var flowerIndex = Random.Range(0, Flowers.Count);
            var flower = Flowers[flowerIndex];
            var position = new Vector3(Random.Range(-1 * radius, radius), 0, Random.Range(-1 * radius, radius));

            var item = Instantiate(flower, transform);
            item.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
