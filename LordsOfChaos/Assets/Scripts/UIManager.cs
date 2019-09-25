using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spellFrame;

    // SINGLETON DESIGN
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowSpellFrame(GameObject unitToCast)
    {
        spellFrame.SetActive(true);
        Image selectedIcon = spellFrame.GetComponent<Image>();
        selectedIcon.sprite = unitToCast.GetComponent<Image>().sprite;
    }

    public void HideSpellFrame()
    {
        spellFrame.SetActive(false);
    }

}
