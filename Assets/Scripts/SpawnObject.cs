using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpawnObject : MonoBehaviour
{
    public InMemoryVariableStorage variables;
    public Transform spawnpoint;
    public Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();

    public GameObject[] prefabs;
    public string[] names;

    string currentObject;
    bool isActive = false;

    private void Start()
    {
        int index = 0;

        foreach(string name in names)
        {
            objects[name] = prefabs[index];
            index++;
        }
    }

    [YarnCommand ("set_new_object")]
    public void SetActiveSpawnObject()
    {
        variables.TryGetValue("currentObject", out currentObject);
    }

    [YarnCommand ("spawn_object")]
    public void Spawn()
    {
        if(currentObject == null) return;
        if (!isActive) return;

        Instantiate(objects[currentObject], spawnpoint.position, Quaternion.identity);
    }
}
