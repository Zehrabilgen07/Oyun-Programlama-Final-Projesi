using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";


    private float horizontalInput;
    private float verticalInput;
    private float anl�kDireksiyonAcisi;
    private float frenGucu;
    private bool isBreaking;

    [SerializeField] private float motorGucu;
    [SerializeField] private float anlikFrenGucu;
    [SerializeField] private float maksimumDireksiyonAc�s�;

    [SerializeField] private WheelCollider onSolTekerCollider;
    [SerializeField] private WheelCollider onSagTekerCollider;
    [SerializeField] private WheelCollider arkaSolTekerCollider;
    [SerializeField] private WheelCollider arkaSagTekerCollider;

    [SerializeField] private Transform onSolTekerTransform;
    [SerializeField] private Transform onSagTekerTransform;
    [SerializeField] private Transform arkaSolTekerTransform;
    [SerializeField] private Transform arkaSagTekerTransform;

    [SerializeField] private GameObject player;


    private void FixedUpdate()
    {
        if(player.activeInHierarchy == false)
        {
            InputAl();
            Motor();
            Direksiyon();
            TekerGuncelle();
        }
       

      
    }



    private void Motor()
    {
        onSolTekerCollider.motorTorque = verticalInput * motorGucu;
        onSagTekerCollider.motorTorque = verticalInput * motorGucu;
        anlikFrenGucu = isBreaking ? frenGucu : 0f;
        if (isBreaking)
        {
            FrenYap();
        }
    }
    private void FrenYap()
    {
        onSolTekerCollider.brakeTorque = anlikFrenGucu;
        onSagTekerCollider.brakeTorque = anlikFrenGucu;
        arkaSolTekerCollider.brakeTorque = anlikFrenGucu;
        arkaSagTekerCollider.brakeTorque = anlikFrenGucu;
    }
    private void Direksiyon()
    {
        anl�kDireksiyonAcisi = maksimumDireksiyonAc�s� * horizontalInput;
        onSolTekerCollider.steerAngle = anl�kDireksiyonAcisi;
        onSagTekerCollider.steerAngle = anl�kDireksiyonAcisi;
    }
    private void InputAl()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
    }

    private void TekerGuncelle()
    {
        TekTekerGuncelle(onSolTekerCollider, onSolTekerTransform);
        TekTekerGuncelle(onSagTekerCollider, onSagTekerTransform);
        TekTekerGuncelle(arkaSolTekerCollider, arkaSolTekerTransform);
        TekTekerGuncelle(arkaSagTekerCollider, arkaSagTekerTransform);
    }

    private void TekTekerGuncelle(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;

    }
 
}
