using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float ShakeCD = 0.004f;		//抖动的频率
    public int ShakeCount = 1;			//设置抖动次数
    private float _shakeTime;


    private Transform cameraTransform;
    private Vector3 _currentPosition;		//记录抖动前的位置

    void Start()
    {
        if (cameraTransform == null) cameraTransform = transform;

        _currentPosition = cameraTransform.position;	//记录抖动前的位置
        
    }


    public void shake()
    {
        StartCoroutine(doShake());
    }

    private IEnumerator doShake()
    {
        int currentShakeCount = ShakeCount;
        while (currentShakeCount-- > 0)
        {

           
            //ShakeCount--;
            float radio = Random.Range(-0.08f, 0.08f);



            print(3);
            cameraTransform.position = _currentPosition + Vector3.one * radio;
            yield return new WaitForSeconds(ShakeCD);
        }

        cameraTransform.position = _currentPosition;

        print(4334);
    }
}
