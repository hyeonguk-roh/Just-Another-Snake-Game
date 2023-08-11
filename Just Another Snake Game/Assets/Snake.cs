using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction;
    private int directionNum = -1;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    public Animator title;
    public Animator cameranimator;
    public Animator gameover;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update()
    {
        if (directionNum == 0) {
            _direction = Vector2.up;
        }
        if (directionNum == 1) {
            _direction = Vector2.right;
        }
        if (directionNum == 2) {
            _direction = Vector2.left;
        }
        if (directionNum == 3) {
            _direction = Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
            Grow();
        }

        if (other.tag == "Obstacle") {
            gameover.SetBool("gameover", true);
        }
    }

    public void PushUp()
    {
        directionNum = 0;
        title.SetBool("started", true);
        cameranimator.SetBool("started", true);
    }

    public void PushRight()
    {
        directionNum = 1;
        title.SetBool("started", true);
        cameranimator.SetBool("started", true);
    }

    public void PushLeft()
    {
        directionNum = 2;
        title.SetBool("started", true);
        cameranimator.SetBool("started", true);
    }

    public void PushDown()
    {
        directionNum = 3;
        title.SetBool("started", true);
        cameranimator.SetBool("started", true);
    }
}
