using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlaceholder : MonoBehaviour
{
    private void Update()
    {
        transform.position += (Input.GetAxisRaw("Horizontal") * transform.forward + Input.GetAxisRaw("Vertical") * transform.right) * Time.deltaTime * 5;
    }
}
