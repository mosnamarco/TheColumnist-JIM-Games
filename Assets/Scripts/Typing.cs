using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Typing : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] keys, special_keys;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private float KeyPressDepth = 0.5f;

    private Dictionary<char, KeyCode> chartoKeycode = new Dictionary<char, KeyCode>() {
        {'a', KeyCode.A},
        {'b', KeyCode.B},
        {'c', KeyCode.C},
        {'d', KeyCode.D},
        {'e', KeyCode.E},
        {'f', KeyCode.F},
        {'g', KeyCode.G},
        {'h', KeyCode.H},
        {'i', KeyCode.I},
        {'j', KeyCode.J},
        {'k', KeyCode.K},
        {'l', KeyCode.L},
        {'m', KeyCode.M},
        {'n', KeyCode.N},
        {'o', KeyCode.O},
        {'p', KeyCode.P},
        {'q', KeyCode.Q},
        {'r', KeyCode.R},
        {'s', KeyCode.S},
        {'t', KeyCode.T},
        {'u', KeyCode.U},
        {'v', KeyCode.V},
        {'w', KeyCode.W},
        {'x', KeyCode.X},
        {'y', KeyCode.Y},
        {'z', KeyCode.Z},
    };

    void Update()
    {
        if (inputField.isFocused) {
            handleKeyDown();
        }
    }

    void handleKeyDown() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            special_keys[0].transform.position -= new Vector3(0, KeyPressDepth, 0);
            SoundManager.instance.KeyHit();
        }
        if (Input.GetKeyUp(KeyCode.Space))
            special_keys[0].transform.position += new Vector3(0, KeyPressDepth, 0);

        foreach (KeyValuePair<char, KeyCode> kp in chartoKeycode) {
            if (Input.GetKeyDown(kp.Value)) {
                Debug.Log((kp.Key - '0') - 49);
                keys[(kp.Key - '0') - 49].transform.position -= new Vector3(0, KeyPressDepth, 0);
                SoundManager.instance.KeyHit();
            }
            if (Input.GetKeyUp(kp.Value))
                keys[(kp.Key - '0') - 49].transform.position += new Vector3(0, KeyPressDepth, 0);
        }

    }

}
