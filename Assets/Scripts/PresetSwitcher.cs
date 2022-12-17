using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.SceneManagement;

public class PresetSwitcher : MonoBehaviour
{
    public static PresetSwitcher Instance = null;

    [SerializeField]
    private List<GameObject> allPresets;

    private int index = 0;

    //[SerializeField]
    private ARFaceManager faceManager;

    private Animator transition;

    private void Awake()
    {
        

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        faceManager = gameObject.GetComponent<ARFaceManager>();
    }

    
    /*
    public void DeleteOldARSessionOrigins()
    {
        GameObject[] allARSessionOrigins = GameObject.FindGameObjectsWithTag("Player");

        for(int i = 1; i < allARSessionOrigins.Length; i++)
        {
            Destroy(allARSessionOrigins[i]);
        }
    }
    */
    

    public void NextPreset()
    {        
        index += 1;
        if (index >= allPresets.Count)
            index = 0;


        //faceManager = FindGame
        faceManager.facePrefab = allPresets[index];
        //faceManager.facePrefab.GetComponent<ARFaceMeshVisualizer>().UpdateVisibility();
        StartCoroutine(LoadLevel());
        Debug.Log("ButtonPressed");
    }

    public void LastPreset()
    {       
        index -= 1;
        if (index < 0)
            index = allPresets.Count;
        
        faceManager.facePrefab = allPresets[index];
        StartCoroutine(LoadLevel());
        Debug.Log("ButtonPressed");
    }

    IEnumerator LoadLevel()
    {
        transition = GameObject.FindGameObjectWithTag("FadeTag").GetComponent<Animator>();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
