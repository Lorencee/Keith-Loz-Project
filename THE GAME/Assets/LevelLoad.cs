using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LevelAsync (sceneIndex));
    }
    IEnumerator LevelAsync(int sceneIndex)
    {
           AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
        
    }

    
}
