using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    private Player _player;
    [SerializeField]
    private CharacterController _playerCharacterController;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = GameObject.Find("Player").GetComponent<Player>();

            if(_player != null)
            {
                _player.Damage();
            }
            
            if (_playerCharacterController != null)
            {
                _playerCharacterController.enabled = false;
            }

            other.transform.position = _respawnPoint.transform.position;

            StartCoroutine(CCEnableRoutine(_playerCharacterController));
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.15f);
        controller.enabled = true;
    }

}
