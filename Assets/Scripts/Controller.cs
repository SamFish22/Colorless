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
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "death"){
            GameOver();
        } else if (collision.collider.tag == "red")
        {
            collision.gameObject.SetActive(false);
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.red);
            
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.green);
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
