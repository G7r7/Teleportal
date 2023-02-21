using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPuzzle : MonoBehaviour
{
    public GameObject obj;
    public Material validMaterial;
    public int countTarget;
    private AudioSource audioSource;
    public Text info;
    public bool isMenuDisplayable;
    public GameObject winMenu;

    private Material oldMaterial;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        oldMaterial = obj.GetComponent<Renderer>().material;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.2f;
        audioSource.clip = Resources.Load<AudioClip>("DM-CGS-45");
        info.text = "Cubes récupérés : " + this.counter + "/" + this.countTarget;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Grabable>() == null) { return; }
        this.counter += 1;
        this.CheckPuzzle();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Grabable>() == null) { return; }
        this.counter -= 1;
        this.CheckPuzzle();
    }

    private bool CheckPuzzle()
    {
        info.text = "Cubes récupérés : " + this.counter + "/" + this.countTarget;

        if (this.counter == countTarget)
        {
            audioSource.Play();
            obj.GetComponent<Renderer>().material = validMaterial;
            if (isMenuDisplayable)
            {
                winMenu.SetActive(true);
            }
            return true;
        }
        obj.GetComponent<Renderer>().material = oldMaterial;
        return false;
    }

    public int getCounter()
    {
        return counter;
    }
}
