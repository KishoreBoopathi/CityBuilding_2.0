using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    private void Start()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(GM.EndTurn);
    }
}
