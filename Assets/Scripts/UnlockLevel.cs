using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class UnlockLevel : MonoBehaviour
{
    
    private Button[] lvlButtons;
    private int totalHearts;
    private int heartCount = 0;
    private Scene scene;
    [SerializeField]
    private int[] heartsHunted;
    [SerializeField]
    private int[] heartsNeeded;
    private readonly int NUM_OF_LEVELS = 6;
    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        totalHearts = 0;
        foreach(int x in heartsHunted)
        {
            totalHearts += x;
        }
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        scene = aScene;
        if (aScene.name == "OptionMenu")
        {
            lvlButtons = FindObjectsOfType<Button>();
            foreach (Button btn in lvlButtons)
            {
                string name = btn.name.Substring(5);
                int lvl = Int32.Parse(name);
                if (totalHearts < heartsNeeded[lvl - 1])
                {
                    btn.GetComponent<Button>().enabled = false;
                }

            }
        }else
        {
            try
            {
                Int32.Parse(aScene.name);
                setUpLevel();
            }
            catch (Exception ee)
            {
               
            }
        }
    }
    private void setUpLevel()
    {
        heartCount = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void addHeartCount()
    {
        heartCount++;
    }
    public void endlevel()
    {
        if(heartCount > heartsHunted[Int32.Parse(scene.name)-1])
        {
            heartsHunted[Int32.Parse(scene.name) - 1] = heartCount;
        }
    }
    public void newGame()
    {
        heartsHunted = new  int[NUM_OF_LEVELS];
    }

}

