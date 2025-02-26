using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform spawnPt;
    public GameObject prefab;
    public float shootSpeed=20;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var bullet=Instantiate(prefab, spawnPt.position,spawnPt.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = spawnPt.forward*shootSpeed;
        }
    }

    public void shoot()
    {
        var bullet = Instantiate(prefab, spawnPt.position, spawnPt.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = spawnPt.forward * shootSpeed;
    }
}
