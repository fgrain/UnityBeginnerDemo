using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LightManager : MonoSingleton<LightManager>
{
    public GameObject[] Lights;
    public PlayerMovement player;
    public Dictionary<string, Hurted> enemies = new Dictionary<string, Hurted>();

    public float TimeEnemyRevival = 3;
    public float TimeLightClose = 15;
    public float TiemLightOpen = 10;
    public void ControllSwitch(GameObject light, bool open)
    {
        light.GetComponentInChildren<Light>().enabled = open;
        light.GetComponentInChildren<SphereCollider>().enabled = open;
        if (light.transform.Find("WallLight"))
        {
            light.transform.Find("WallLight").gameObject.SetActive(open);
        }
    }
}
