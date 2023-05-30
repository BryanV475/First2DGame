using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer background;

    public GameObject column;

    public GameObject rock;

    public List<GameObject> columns = new List<GameObject>();

    public List<GameObject> obstacles = new List<GameObject>();

    public float mapVelocity = 2;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Map Generation
        for (int i = 0; i < 21; i++)
        {
            columns.Add(
                Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity)
            );
        }

        //Obstacle Creation
        obstacles.Add(
            Instantiate(rock, new Vector2(14, -2), Quaternion.identity)
            ); ;
    }

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

        // Map Moving
        for (int i = 0; i < columns.Count; i++)
        {
            if (columns[i].transform.position.x <= -10)
            {
                columns[i].transform.position = new Vector3(10, -3, 0);
            }
            columns[i].transform.position = columns[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * mapVelocity;
        }

        // Obstacle Moving
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].transform.position.x <= -10)
            {
                obstacles[i].transform.position = new Vector3(11, -2, 0);
            }
            obstacles[i].transform.position = obstacles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * mapVelocity;
        }
    }

    public void GameOver()
    {
        // Reboot the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
