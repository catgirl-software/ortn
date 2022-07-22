using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStacker : MonoBehaviour
{

    [SerializeField] string path;
    List<GameObject> layers = new();

    // Start is called before the first frame update
    void Start()
    {
        var sprites = Resources.LoadAll<Sprite>(path);

        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newlayer = new();
            newlayer.AddComponent<SpriteRenderer>();
            newlayer.GetComponent<SpriteRenderer>().sprite = sprites[i];
            newlayer.transform.position = transform.position + new Vector3(0, 1.0f/16 * i, 0);
            newlayer.transform.parent = transform;

            layers.Add(newlayer);
        }
    }

    private void Update()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            layers[i].transform.position = transform.position + new Vector3(0, 1.0f / 16 * i, 0);
        }
    }
}
