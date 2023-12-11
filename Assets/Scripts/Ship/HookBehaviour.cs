using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    private SpriteRenderer _ropeSprite;

    private GameObject _ropeObject;

    [SerializeField] private float speed;

    private Vector3 _initialPos;

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
        _ropeObject = GameObject.Find("Rope");
        _ropeSprite = _ropeObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mouseWorldPos = default;
        if (!Input.GetKey(KeyCode.Space))
        {
            LookAtMouse();
            return;
        }

        StartCoroutine(ThrowHook());

        return;

        void LookAtMouse()
        {
            var position = transform.position;
            _ropeSprite.size = new Vector2(Vector2.Distance(GANCA.initialPosition, position), _ropeSprite.size.y);
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float angle = Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -360, 360);
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }

        bool IsInRotateArea()
        {
            // Eğer rotate olduğu alanda ise true döndür
            float angle = Mathf.Atan2(transform.position.y - _initialPos.y, transform.position.x - _initialPos.x) *
                          Mathf.Rad2Deg;
            float currentAngle = transform.eulerAngles.y;

            var isInRotateArea = Mathf.Abs(Mathf.DeltaAngle(angle, currentAngle)) < 360 / 2f;
            Debug.Log(isInRotateArea);
            return isInRotateArea;
        }

        void MoveStraightTowards(Vector3 targetPosition)
        {
            // Hedef konuma doğru düz bir çizgide ilerle
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        bool GotToTarget(Vector3 targetPosition)
        {
            // Eğer hedef konuma ulaşıldıysa, başlangıç pozisyonuna geri dön
            return Vector3.Distance(transform.position, targetPosition) < 0.1f;
        }

        bool OnInitialPos()
        {
            var position = transform.position;
            return Math.Abs(position.x - _initialPos.x) < 0.2f && Math.Abs(position.y - _initialPos.y) < 0.2f;
        }

        IEnumerator ThrowHook()
        {
            while (!IsInRotateArea())
            {
                LookAtMouse();
                yield return null;
            }

            while (!GotToTarget(mouseWorldPos))
            {
                MoveStraightTowards(mouseWorldPos);
                yield return null;
            }

            while (!OnInitialPos())
            {
                MoveStraightTowards(_initialPos);
                yield return null;
            }
        }
    }
}