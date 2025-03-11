using System.Collections;
using TMPro;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Collider BottomTrigger;

    public TMP_Text Points;
    public Collider LeftTen;
    public Collider LeftTwenty;
    public Collider Thirty;
    public Collider RightTwenty;
    public Collider RightTen;
    public int points = 0;

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

        if(other == LeftTen || other == RightTen)
        {
            points += 10;
            Points.text = points.ToString();
        }

        if(other == LeftTwenty || other == RightTwenty)
        {
            points += 20;
            Points.text = points.ToString();
        }

        if(other == Thirty)
        {
            points += 30;
            Points.text = points.ToString();
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
