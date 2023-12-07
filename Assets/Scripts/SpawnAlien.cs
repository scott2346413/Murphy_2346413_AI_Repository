using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpawnAlien : MonoBehaviour
{
    public InMemoryVariableStorage variables;
    public Transform spawnpoint;
    public Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();

    public GameObject[] prefabs;
    public string[] names;

    string currentObject;

    private void Start()
    {
        int index = 0;

        foreach(string name in names)
        {
            objects[name] = prefabs[index];
            index++;
        }
    }

    [YarnCommand ("set_object_phirakian")]
    public void setObjectPhirakian()
    {
        currentObject = "Phirakian";
    }

    [YarnCommand("set_object_glopite")]
    public void setObjectGlopite()
    {
        currentObject = "Glopite";
    }

    [YarnCommand("set_object_echolyth")]
    public void setObjectEcholyth()
    {
        currentObject = "Echolyth";
    }

    [YarnCommand ("spawn_object")]
    public void Spawn()
    {
        if(currentObject == null) return;

        objects[currentObject].SetActive(true);
    }
}
