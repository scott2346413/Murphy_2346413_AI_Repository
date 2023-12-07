using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCManager : MonoBehaviour
{
    NPC3D[] NPCs;

    public DialogueRunner dialogueRunner;
    public GameObject dialogueCanvas;

    // Update is called once per frame
    void Update()
    {
        NPCs = FindObjectsOfType<NPC3D>();

        foreach (NPC3D npc in NPCs)
        {
            if (npc.dialogueRunner == null || npc.dialogueCanvas == null)
            {
                npc.dialogueRunner = dialogueRunner;
                npc.dialogueCanvas = dialogueCanvas;
            }
        }
    }
}
