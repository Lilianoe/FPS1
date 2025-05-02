using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool LETMEINNNN = false;
    public GameObject DoorUp;
    public GameObject DoorDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
            LETMEINNNN = true;
    }
    void OnTriggerExit(Collider other)
    {
         LETMEINNNN = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(LETMEINNNN == true)
        {
            if(DoorUp.transform.position.y <= 5.7f)
                {
                    Debug.Log("Jesuis la 1");
                    DoorUp.transform.position = new Vector3(DoorUp.transform.position.x, DoorUp.transform.position.y+0.05f, DoorUp.transform.position.z);
                }

            if(DoorDown.transform.position.y > -1.8f)
                {
                    Debug.Log("Jesuis la 1");
                    DoorDown.transform.position = new Vector3(DoorDown.transform.position.x, DoorDown.transform.position.y-0.05f, DoorDown.transform.position.z);
                }
        }
        else
        {
            if(DoorUp.transform.position.y >= 4.0f)
                {
                    Debug.Log("Jesuis la 2");
                    DoorUp.transform.position = new Vector3(DoorUp.transform.position.x, DoorUp.transform.position.y-0.05f, DoorUp.transform.position.z);
                }

            if(DoorDown.transform.position.y < 0)
                {
                    Debug.Log("Jesuis la 2");
                    DoorDown.transform.position = new Vector3(DoorDown.transform.position.x, DoorDown.transform.position.y+0.05f, DoorDown.transform.position.z);
                }
        }
    }
}
