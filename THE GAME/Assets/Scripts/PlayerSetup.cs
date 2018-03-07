
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
   [SerializeField]
    Behaviour[] Components;

    Camera SceneCam;
    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].enabled = false;
            }
        }
        else
        {
            SceneCam = Camera.main;
            if (SceneCam != null) {
                SceneCam.gameObject.SetActive(false);
            }

        }
    }
    void OnDisable()
    {
        if (SceneCam !=null)
        {
            SceneCam.gameObject.SetActive(true);
        }

    }
}
