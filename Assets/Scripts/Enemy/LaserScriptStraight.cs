using UnityEngine;

namespace Enemy
{
    public class LaserScriptStraight : MonoBehaviour
    {
        public float destroyTime;
        public float speed;
        private Vector3 _targetPos;
        private Vector3 _direction;
        private Rigidbody2D _rb;
        private Transform _player;
        [SerializeField] private GameObject meteorPrefab;
        private Collider2D _thisCollider;
    
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, destroyTime);
            _player = GameObject.FindWithTag("Player").transform;
            _targetPos = new Vector2(_player.transform.position.x - 100, transform.position.y);
            _targetPos.z = 0f;
            _rb = GetComponent<Rigidbody2D>();
            _direction = (_targetPos - transform.position).normalized * speed;
            _rb.velocity = new Vector2(_direction.x, _direction.y);
            _thisCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            _rb.velocity = _direction;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == _thisCollider) return;
            if (!other.transform.TryGetComponent(out HealthCounter healthCounter)) return;
            healthCounter.CurrentHealth -= 15;
            if (healthCounter.CurrentHealth <= 0)
            {
                if (other.transform.CompareTag("BigMeteor"))
                {
                    var position = other.transform.position;
                    Instantiate(meteorPrefab, new Vector3(position.x + 1, position.y + 1), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                    Instantiate(meteorPrefab, new Vector3(position.x - 1, position.y - 1), Quaternion.identity)
                        .GetComponent<Rigidbody2D>().velocity = new Vector2(-MeteoriteSpawner.solaDogruHiz, 0f);
                }
            }
        }
    }
}
