using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookClick : MonoBehaviour
{

    public GameObject spellBookPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }


    public void OperateSpellBook()
    {
        if (spellBookPanel.activeSelf == true)
        {
            spellBookPanel.SetActive(false);
        }
        else
        {
            spellBookPanel.SetActive(true);
        }


    }
}
