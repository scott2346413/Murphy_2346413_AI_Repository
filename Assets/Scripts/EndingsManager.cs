using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class EndingsManager : MonoBehaviour
{
    public string[] endingTitles;
    public string[] endings;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject noise;

    [YarnCommand("set_ending_1")]
    public void EndingOne()
    {
        SetEnding(1);
    }

    [YarnCommand("set_ending_2")]
    public void EndingTwo()
    {
        SetEnding(2);
    }

    [YarnCommand("set_ending_3")]
    public void EndingThree()
    {
        SetEnding(3);
    }

    [YarnCommand("set_ending_4")]
    public void EndingFour()
    {
        SetEnding(4);
    }

    [YarnCommand("set_ending_5")]
    public void EndingFive()
    {
        SetEnding(5);
    }

    [YarnCommand("set_ending_6")]
    public void EndingSix()
    {
        SetEnding(6);
    }

    [YarnCommand("set_ending_7")]
    public void EndingSeven()
    {
        SetEnding(7);
    }

    public void SetEnding(int ending)
    {
        title.text = endingTitles[ending-1];
        description.text = endings[ending-1];
        noise.SetActive(true);
    }
}
