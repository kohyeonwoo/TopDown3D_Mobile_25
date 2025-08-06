using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;

    public float smoothFollow;

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position,
            Time.deltaTime * smoothFollow);
    }

}
