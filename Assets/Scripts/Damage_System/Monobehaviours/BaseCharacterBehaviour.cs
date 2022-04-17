using UnityEngine;

public class BaseCharacterBehaviour : MonoBehaviour
{
    [SerializeField] private BaseDamageableCharacter damageableCharacter;
    private void Start()
    {
        damageableCharacter = new BaseDamageableCharacter();
        damageableCharacter.Initialize();
    }

}
