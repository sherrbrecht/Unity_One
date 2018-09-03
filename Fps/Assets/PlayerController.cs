using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private PlayerMotor _motor;

    private void Start()
    {
        _motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {

        /* Vélocité du mouvement (...direction & vitesse...) */

        float _xMove = Input.GetAxisRaw("Horizontal");
        /*
         -1 = gauche
         0 = le personnage ne bouge pas
         1 = droite
         */

        float _zMove = Input.GetAxisRaw("Vertical");
        /*
         -1 = recule
         0 = le personnage ne bouge pas
         1 = avance

         */

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        _motor.Move(_velocity);

    }
}
