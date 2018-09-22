using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject MovingBlocker;
    public GameObject EndPosition;
    public GameObject StartPosition;
    public Text WallCountText;

    private int WallCount;

    void Start()
    {
        WallCount = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        if (WallCount == 0)

        {
            transform.position = Vector3.MoveTowards(transform.position, EndPosition.transform.position, Speed * Time.deltaTime);
            //WallCount = 1;
        }
            
        //else if (WallCount == 1)

        {
            //transform.position = Vector3.MoveTowards(transform.position, StartPosition.transform.position, Speed * Time.deltaTime);
            //WallCount = 0;
        }
    }
}
