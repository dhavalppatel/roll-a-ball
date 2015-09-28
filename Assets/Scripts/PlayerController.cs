using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private float horizMovement;
    private float vertMovement;

    private int count;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        horizMovement = Input.GetAxis("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizMovement, 0.0f, vertMovement) * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
