using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPuzzle : MonoBehaviour
{
    public GameObject obj;
    public Material validMaterial;
    public int countTarget;
    public Text debugtext;
    
    private Material oldMaterial;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        oldMaterial = obj.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        this.counter += 1;
        this.CheckPuzzle();
    }

    private void OnTriggerExit(Collider other)
    {
        this.counter -= 1;
        this.CheckPuzzle();
    }

    private bool CheckPuzzle()
    {
        this.debugtext.text = "Nombre d'éléments : " + this.counter.ToString();
        if (this.counter == countTarget)
        {
            obj.GetComponent<Renderer>().material = validMaterial;
            return true;
        }
        obj.GetComponent<Renderer>().material = oldMaterial;
        return false;
    }
}
