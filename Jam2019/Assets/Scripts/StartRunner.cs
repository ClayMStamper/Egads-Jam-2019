using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRunner : MonoBehaviour
{
    public bool running = false;
    private float timeElapsed = 0.0f;

    public List<float> DialogTimes = new List<float>();
    public List<string> DialogEntries = new List<string>();
    private int currentDialog = 0;

    public Text dialogText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Run()
    {
        running = true;
        timeElapsed = 0.0f;
        dialogText.gameObject.SetActive(true);
    }

    public bool IsRunning()
    {
        return running;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            return;
        }

        timeElapsed += Time.deltaTime;
        if (timeElapsed > DialogTimes[currentDialog])
        {

            dialogText.text = DialogEntries[currentDialog];
            timeElapsed = 0.0f;
            currentDialog++;

        }
        if (currentDialog >= DialogTimes.Count)
        {
            running = false;
            currentDialog = 0;
        }
    }
}