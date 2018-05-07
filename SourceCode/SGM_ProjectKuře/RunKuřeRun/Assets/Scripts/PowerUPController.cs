using UnityEngine;

public class PowerUPController : MonoBehaviour {
    public int playerNO;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _mine;

    private bool _isBomb;
    private int _powerUPCount = 0;

    private bool m_isAxisInUse = false;

    public void GivePowerUP() {
        _powerUPCount = 3;
        _isBomb = Random.value > 0.5f;
    }

    private void Update() {
        if (Input.GetAxisRaw("Fire_" + playerNO) > 0 && _powerUPCount > 0) {
            if (m_isAxisInUse == false) {
                if (_isBomb) {
                    Bomb();
                }
                else {
                    Mine();
                }

                _powerUPCount--;
                m_isAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Fire_" + playerNO) == 0) {
            m_isAxisInUse = false;
        }
    }

    private void Mine() {
        Vector3 minePosition = transform.position + new Vector3(-0.4f, -0.15f, 0);
        Instantiate(_mine, minePosition, Quaternion.identity);
    }

    private void Bomb() {
        Vector3 bombPosition = transform.position + new Vector3(0.25f, 0.5f, 0);
        Instantiate(_bomb, bombPosition, Quaternion.identity);
    }
}