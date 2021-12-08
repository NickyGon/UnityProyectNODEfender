using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPowerUp : MonoBehaviour
{
    [SerializeField] private float DistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public bool shootIt = false;
    public float countdownInput;
    float lasercountdown;

  

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (shootIt && lasercountdown>0)
        {
                lasercountdown -= Time.deltaTime;
                m_lineRenderer.enabled = true;
                ShootLaser();
                
        } else
        {
            shootIt = false;
            lasercountdown = countdownInput;
            m_lineRenderer.enabled = false;
        }
    }
    void ShootLaser()
    {

        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position,transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
            EnemyController enemy = _hit.collider.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.takeDamage();
            }
        } else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * DistanceRay);
        }
    }

    void Draw2DRay(Vector2 start, Vector2 end)
    {
        m_lineRenderer.SetPosition(0, start);
        m_lineRenderer.SetPosition(1, end);
    }
}
