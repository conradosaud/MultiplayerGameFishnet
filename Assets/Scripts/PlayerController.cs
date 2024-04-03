
using FishNet.Object;
using TMPro;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    public float velocidade = 5f;
    public float pontos = 0;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner == false)
            transform.Find("Main Camera").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (base.IsOwner)
            Mover();
    }

    void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento *= velocidade * Time.deltaTime;

        transform.Translate(movimento);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coletavel"))
        {
            Destroy(other.gameObject);
        }
    }

}
