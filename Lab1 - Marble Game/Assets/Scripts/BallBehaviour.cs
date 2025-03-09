using System.Collections;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Collider BottomTrigger;

    public Collider LeftTen;
    public Collider LeftTwenty;
    public Collider Thirty;
    public Collider RightTwenty;
    public Collider RightTen;

    public float MinZPosition = -0.46f;
    public float MaxZPosition = 0.49f;

    private Vector3 InitialPosition;
    private Rigidbody rb;
    private bool isResetingBall = false;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = new Vector3(-2.029f, 2.21f, 0.078f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == BottomTrigger && !isResetingBall)
        {
            StartCoroutine(ResetBall());
        }
    }

    private IEnumerator ResetBall()
    {
        isResetingBall = true;
        yield return new WaitForSeconds(1f);

        this.enabled = false;
        rb.isKinematic = true;

        var newPosition = InitialPosition;

        newPosition.z = Random.Range(MinZPosition, MaxZPosition);

        transform.position = newPosition;

        this.enabled = true;
        rb.isKinematic = false;
        isResetingBall = false;
    }
}
