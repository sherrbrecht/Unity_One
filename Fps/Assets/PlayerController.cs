using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    //inspector data input
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f; // sensibiité souris (du regard)

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
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

        motor.Move(_velocity);

        //On va calculer la rotation du joueur en un vecteur 3D

        //Axe Horizontal
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        motor.Rotate(_rotation);

        

    }
}
