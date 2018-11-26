using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CentralController : MonoBehaviour {
    
    public GameObject[] shapes;
    public GameObject[] buttons;

    public float startTime;

    private int finishCounter;
    private Vector3 scale = new Vector3(0, 0, 0);
    private bool finito;

    void Start () 
    {
        finishCounter = buttons.Length;
        finito = false;
    }
	
	void Update ()
    {

        // Handles choosing of shapes in scene

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "shape")
                {
                    for (int i = 0; i < shapes.Length; i++)
                    {
                        shapes[i].GetComponent<shapeController>().selected = false;
                    }

                    shapeController shapeHit = hit.transform.GetComponent<shapeController>();
                    shapeHit.selected = true;
                }
            }
        }

        // Handles button presses

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<buttonControl>().pressed == true)
            {
                buttons[i].GetComponent<Transform>().localScale = scale;
                finishCounter--;
            }
        }

        if (finishCounter <= 0 && finito == false)
        {
            Timing();
            finito = true;
            Debug.Log("Finished!");
        }
    }

    // Handles everything that has to do with the beginning of the test

    public void StartUp()   
    {
        GameObject startButton = GameObject.Find("Button");
        startButton.active = false;

        GameObject curtain = GameObject.Find("Image");
        curtain.active = false;

        startTime = Time.time;
    }

    // Handles everything that has to do with the timing of participants and saving results

    private void Timing()
    {
        float endTime = Time.time;
        float finalTime = endTime - startTime;

        string path = "/Users/ThomasLund/Desktop/MPC_Mini_Project/Assets/results/results.txt";

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(finalTime);
        writer.Close();
    }
}
