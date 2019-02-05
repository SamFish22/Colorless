using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour

{
    private int points;
    private float speed;
    public TextMesh textPoint;
    private Vector3 jump;
    private Renderer rend;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        points = 70;
        speed = 8f;
        jump.Set(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Camera.main.transform.localRotation;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);  //https://answers.unity.com/questions/1367178/set-fixed-rotation-position-of-object-in-world-spa.html

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "death"){
            GameOver();
        } else if (collision.collider.tag == "yellow")
        {
            collision.gameObject.SetActive(false);
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.yellow);
            
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.blue);
        }
        else if (collision.collider.tag == "red")
        {
            collision.gameObject.SetActive(false);
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.red);

            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.green);
        }
        else if (collision.collider.tag == "blue")
        {
            collision.gameObject.SetActive(false);
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);

            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.yellow);
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
