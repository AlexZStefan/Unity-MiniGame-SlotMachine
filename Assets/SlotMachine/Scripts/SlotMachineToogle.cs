
using UnityEngine;

public class SlotMachineToogle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool priv_CheckCollision_bool;

    [SerializeField]
    private Camera priv_mainCamera_camera;

    [SerializeField]
    private Camera priv_slotsCamera_camera;

    private bool priv_CanvasToogle_bool;

    private void Start()
    {
        priv_mainCamera_camera.enabled = true;
        priv_slotsCamera_camera.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            priv_CheckCollision_bool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            priv_CheckCollision_bool = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (priv_CheckCollision_bool == true)
        {
            //detect when the e arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.E))
            {
                priv_mainCamera_camera.enabled = !priv_mainCamera_camera.enabled;
                priv_slotsCamera_camera.enabled = !priv_slotsCamera_camera.enabled;
            }
        }
    }
}
