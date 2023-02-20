using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public CountPuzzle puzzle;

    public GameObject gate;

    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if (puzzle.getCounter() == puzzle.countTarget)
        {
            gate.SetActive(true);
        }
        else
        {
            gate.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Teleportable>() == null) { return; }
        SceneManager.LoadScene(sceneName);
    }
}
