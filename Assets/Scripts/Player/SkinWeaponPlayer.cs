using UnityEngine;

public class SkinWeaponPlayer : MonoBehaviour
{
    public Transform[] _spawnWeaponPos;
    [SerializeField] private GameObject[] skinWeaponPlayer;
    [SerializeField] private GameObject shotGunForGetUp;

    private void Start()
    {
        ChooseWeaponPlayer(SaveManager.instance.currentWeapon, SaveManager.instance.currentWeaponTwo);
    }

    private void ChooseWeaponPlayer(int firstWeapon, int secondWeapon)
    {
        if (firstWeapon == 0 && secondWeapon == 0)
        {
            GameObject weapon = Instantiate(skinWeaponPlayer[firstWeapon], -_spawnWeaponPos[firstWeapon].transform.position, Quaternion.identity);
            weapon.transform.SetParent(transform, false);
            Debug.Log("OneWeapon");
        }
        else
        {
            GameObject weapon = Instantiate(skinWeaponPlayer[firstWeapon], -_spawnWeaponPos[firstWeapon].transform.position, Quaternion.identity);
            weapon.transform.SetParent(transform, false);

            GameObject weaponTwo = Instantiate(skinWeaponPlayer[secondWeapon], -_spawnWeaponPos[secondWeapon].transform.position, Quaternion.identity);
            weaponTwo.transform.SetParent(transform, false);
            weaponTwo.SetActive(false);
            Debug.Log("TwoWeapon");
        }
    }

    public void SpawnShotGun()
    {
        GameObject weaponTwo = Instantiate(shotGunForGetUp,-new Vector3(0.079f, 1.122f, 0), Quaternion.identity);
        weaponTwo.transform.SetParent(transform, false);
        weaponTwo.SetActive(false);
        Debug.Log("GetShotGun");
    }
}
