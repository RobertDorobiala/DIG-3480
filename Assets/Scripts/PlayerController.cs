using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text pointsText;
    public Text pickupText;
    public GameObject NorthWall;

    private Rigidbody rb;
    private int count;
    private int pickup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        pickup = 0;
        SetCountText();
        winText.text = "";
        pointsText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKey("escape"))
            Application.Quit();

        rb.AddForce(movement * speed);

        if (pickup >= 12)
        {
            Destroy(NorthWall);
        }
    }
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            pickup = pickup + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Bad Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString();
        pickupText.text = "Pickups: " + pickup.ToString();

        if (pickup >= 20)
        {
            winText.text = "You Win!";
            pointsText.text = "You Finished with a score of:" + count;
        }
    }
}