using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rigidbody;
    bool dice = true;
    public bool isSleep = false;
    [SerializeField]
    Transform[] diceNumber;
    public int topIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dice)
        {
            rigidbody.angularVelocity = new Vector3(10, 10, 5);
            if (Input.GetMouseButton(0))
            {
                rigidbody.useGravity = true;
                rigidbody.AddForce(new Vector3(-1000, 1000, 0));
                dice = false;
            }
        }

        if (!isSleep && rigidbody.IsSleeping())
        {
            isSleep = true;
            
            var topValue = diceNumber[0].transform.position.y;
            for (var i = 1; i < diceNumber.Length; ++i)
            {
                if (diceNumber[i].transform.position.y < topValue)
                    continue;
                topValue = diceNumber[i].transform.position.y;
                topIndex = i;
            }
            Debug.Log(topIndex + 1);
        }
    }
}
