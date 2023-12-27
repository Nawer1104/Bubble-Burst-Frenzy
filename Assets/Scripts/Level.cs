using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public float level_spawnInterval;

    public float score_current;
    public float score_required;

    public TextMeshProUGUI text;


    private void Start()
    {
        score_current = 0;
        SetText();
    }

    public void SetText()
    {
        text.SetText("Score: {0} / {1}", score_current, score_required);
        if (score_current >= score_required)
        {
            GameManager.Instance.CheckLevelUp();
        }
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
