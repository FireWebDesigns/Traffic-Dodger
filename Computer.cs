using UnityEngine;

public class AICarController : MonoBehaviour
{
    public float speed = 5f;
    public float laneWidth = 3f; // Adjust this value based on your lane width

    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Adjust the car's position to stay within its lane
        KeepWithinLane();
    }

    void KeepWithinLane()
    {
        RaycastHit leftHit, rightHit;

        // Raycast to the left to detect the left boundary
        if (Physics.Raycast(transform.position, -transform.right, out leftHit, laneWidth / 2f, LayerMask.GetMask("Road")))
        {
            transform.position = new Vector3(leftHit.point.x + laneWidth / 2f, transform.position.y, transform.position.z);
        }

        // Raycast to the right to detect the right boundary
        if (Physics.Raycast(transform.position, transform.right, out rightHit, laneWidth / 2f, LayerMask.GetMask("Road")))
        {
            transform.position = new Vector3(rightHit.point.x - laneWidth / 2f, transform.position.y, transform.position.z);
        }
    }
}
