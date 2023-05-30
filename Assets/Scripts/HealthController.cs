using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    
    public Player player;

    private TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshPro>();
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.health.ToString();
    }
}
