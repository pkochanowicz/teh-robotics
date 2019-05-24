using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float xMargin = 1f;
    public float yMargin = 4f;
    public float xSmooth = 8f;
    public float ySmooth = 8f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    [SerializeField]
    private GameObject leftTopFollowingBound;
    [SerializeField]
    private GameObject rightBottomFollowingBound;

    public Transform target;

    public void freezeCamera()
    {

    }

    bool targetOutOfXMargin()
    {
        return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
    }


    bool targetOutOfYMargin()
    {
        return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector2 newCameraPos = transform.position;

        if (targetOutOfXMargin())
            newCameraPos.x = Mathf.Lerp(newCameraPos.x, target.position.x, xSmooth * Time.deltaTime);

        if (targetOutOfYMargin())
            newCameraPos.y = Mathf.Lerp(newCameraPos.y, target.position.y, ySmooth * Time.deltaTime);

        newCameraPos = clipCameraPosition(newCameraPos);

        transform.position = new Vector3(newCameraPos.x , newCameraPos.y, transform.position.z);
    }

    private Vector2 clipCameraPosition(Vector2 cameraPos)
    {
        Vector3 leftTopPos = leftTopFollowingBound.transform.position;
        Vector3 rightBottomPos = rightBottomFollowingBound.transform.position;

        cameraPos.x = Mathf.Max(cameraPos.x, leftTopPos.x);
        cameraPos.x = Mathf.Min(cameraPos.x, rightBottomPos.x);

        cameraPos.y = Mathf.Min(cameraPos.y, leftTopPos.y);
        cameraPos.y = Mathf.Max(cameraPos.y, rightBottomPos.y);

        return cameraPos;
    }
}