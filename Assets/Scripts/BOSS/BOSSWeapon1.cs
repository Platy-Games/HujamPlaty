using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOSSWeapon1 : MonoBehaviour
{
    GameObject BOSShip;
    public GameObject bulletPrefab;
    private bool _isCooldownOver;
    [SerializeField] private float cooldown ;
    Vector2 newPoison;
    void Start()
    {
        BOSShip = GameObject.FindGameObjectWithTag("BOSShip");
        //gameObject.transform.SetAsLastSibling();
        _isCooldownOver = true;

    }

    // Update is called once per frame
    void Update()
    {
        newPoison = new Vector2(BOSShip.transform.position.x - 5f, BOSShip.transform.position.y+3.5f);
        this.transform.position = newPoison;
        
        if (_isCooldownOver)
            {
                StartCoroutine(SetCooldown());
                CreateABullet();
            }

    }
    void CreateABullet()
    {
        var position = transform.position;
        Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
    }

    private IEnumerator SetCooldown()
    {
        _isCooldownOver = false;
        yield return new WaitForSeconds(1);
        _isCooldownOver = true;
    }

    //gameObject.transform.SetAsLastSibling();

    //Vector3 newPosition = gameObject.transform.position;
    //newPosition.x = (BOSShip.transform.position.x-2) + gameObject.transform.position.x;
    //newPosition.y = BOSShip.transform.position.y + gameObject.transform.position.y;
}
