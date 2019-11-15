using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    public Toggle fullscreenTogle;
    public ResolutionItem[] resolutionScale;

    public int selectedResolution;
    public Text resolutionText;


    // Start is called before the first frame update
    void Start()
    {        
        fullscreenTogle.isOn = Screen.fullScreen;

        bool foundResolution = false;
        for(int i = 0;i<resolutionScale.Length;i++)
        {
            if(Screen.width == resolutionScale[i].horizontal && Screen.height == resolutionScale[i].vertical)
            {
                foundResolution = true;

                selectedResolution = i;

                resolutionText.text = resolutionScale[i].horizontal.ToString() + "x" + resolutionScale[i].vertical.ToString();
            }
        }

        if(!foundResolution)
        {
            selectedResolution = 2;
            resolutionText.text = Screen.width.ToString() + "x" + Screen.height.ToString();
            
            Screen.fullScreen = false;
            fullscreenTogle.isOn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftTap()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }

        resolutionText.text = resolutionScale[selectedResolution].horizontal.ToString() + "x" + resolutionScale[selectedResolution].vertical.ToString();
    }

    public void RightTap()
    {
        selectedResolution++;
        if(selectedResolution > resolutionScale.Length - 1)
        {
            selectedResolution = resolutionScale.Length - 1;
        }
        resolutionText.text = resolutionScale[selectedResolution].horizontal.ToString() + "x" + resolutionScale[selectedResolution].vertical.ToString();
    }    

    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTogle.isOn; 
        Screen.SetResolution(resolutionScale[selectedResolution].horizontal, resolutionScale[selectedResolution].vertical, fullscreenTogle.isOn);
    }
}


[System.Serializable]
public class ResolutionItem
{
    public int horizontal, vertical;
}