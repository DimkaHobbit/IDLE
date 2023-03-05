using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemsManager : MonoBehaviour
{
    public PlayerStats playerStats;

    [Space]

    public float costFactor;
    public float tapIncomeFactor;
    public float passIncomeFactor;

    [Space]

    public GameObject itemPrefab;
    public GameObject scrollRect;
    public GameObject[] contentTabs;
    public Toggle[] toggleTabs;

    [Space]
    
    [SerializeField] public ItemProperty[] property;
    [SerializeField] public ItemProperty[] technique;
    [SerializeField] public ItemProperty[] fashion;
    [SerializeField] public ItemProperty[] skills;

    private List<GameObject> propertyLinks = new List<GameObject>();
    private List<GameObject> techniqueLinks = new List<GameObject>();
    private List<GameObject> fashionLinks = new List<GameObject>();
    private List<GameObject> skillsLinks = new List<GameObject>();

    private void Start()
    {
        CreateItems();
    }

    private void OnApplicationQuit()
    {
        UpdateItemsInfo();
    }

    public void OpenTab(int tabNumber)
    {
        for (int step = 0; step < contentTabs.Length; step++)
        {
            if (step != tabNumber)
            {
                contentTabs[step].gameObject.SetActive(false);
            }
            else
            {
                if (!contentTabs[step].activeInHierarchy)
                {
                    contentTabs[step].gameObject.SetActive(true);
                    scrollRect.GetComponent<ScrollRect>().content = contentTabs[step].GetComponent<RectTransform>();
                    scrollRect.SetActive(true);
                }
                else
                {
                    contentTabs[step].gameObject.SetActive(false);
                    scrollRect.SetActive(false);
                }
            }
        }
    }

    private void CreateItems()
    {
        for (int step = 0; step < property.Length; step++)
        {
            GameObject itemTemp = Instantiate(itemPrefab, transform.position, Quaternion.identity, contentTabs[0].transform);
            Item itemTempScript = itemTemp.GetComponent<Item>();
            itemTempScript.itemProperty = property[step];
            itemTempScript.SetProperties(this, playerStats);

            propertyLinks.Add(itemTempScript.gameObject);
        }

        for (int step = 0; step < technique.Length; step++)
        {
            GameObject itemTemp = Instantiate(itemPrefab, transform.position, Quaternion.identity, contentTabs[1].transform);
            Item itemTempScript = itemTemp.GetComponent<Item>();
            itemTempScript.itemProperty = technique[step];
            itemTempScript.SetProperties(this, playerStats);

            techniqueLinks.Add(itemTempScript.gameObject);
        }

        for (int step = 0; step < fashion.Length; step++)
        {
            GameObject itemTemp = Instantiate(itemPrefab, transform.position, Quaternion.identity, contentTabs[2].transform);
            Item itemTempScript = itemTemp.GetComponent<Item>();
            itemTempScript.itemProperty = fashion[step];
            itemTempScript.SetProperties(this, playerStats);

            fashionLinks.Add(itemTempScript.gameObject);
        }

        for (int step = 0; step < skills.Length; step++)
        {
            GameObject itemTemp = Instantiate(itemPrefab, transform.position, Quaternion.identity, contentTabs[3].transform);
            Item itemTempScript = itemTemp.GetComponent<Item>();
            itemTempScript.itemProperty = skills[step];
            itemTempScript.SetProperties(this, playerStats);

            skillsLinks.Add(itemTempScript.gameObject);
        }
    }

    public void UpdateItemsInfo()
    {
        for (int step = 0; step < property.Length; step++)
        {
            property[step] = propertyLinks[step].GetComponent<Item>().itemProperty;
        }

        for (int step = 0; step < technique.Length; step++)
        {
            technique[step] = techniqueLinks[step].GetComponent<Item>().itemProperty;
        }

        for (int step = 0; step < fashion.Length; step++)
        {
            fashion[step] = fashionLinks[step].GetComponent<Item>().itemProperty;
        }

        for (int step = 0; step < skills.Length; step++)
        {
            skills[step] = skillsLinks[step].GetComponent<Item>().itemProperty;
        }
    }
}
