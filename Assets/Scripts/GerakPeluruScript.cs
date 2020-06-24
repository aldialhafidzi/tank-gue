using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPeluruScript : MonoBehaviour
{
    private Transform myTransform;
    private TankBehaviorScript tankBehavior;

    public float _waktuTerbangPeluru;
    public float _jarakTembak;
    private float _kecAwal;
    private float _sudutTembak;
    private float _gravitasi;
    private float _sudutMeriam;
    private Vector3 _posisiAwal;

    public GameObject ledakan;
    public AudioClip audioLedakan;
    public AudioSource audioSource;

    private GameManegerScript gameManeger;
    private bool isLanded = true;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;

        tankBehavior = GameObject.FindObjectOfType<TankBehaviorScript>();
        gameManeger = GameManegerScript.FindObjectOfType<GameManegerScript>();
        _kecAwal = tankBehavior.kecepatanAwalPeluru;
        _sudutTembak = tankBehavior.nilaiRotasiY;
        _gravitasi = tankBehavior.gravitasi;
        _sudutMeriam = tankBehavior.sudutMeriam;

        _posisiAwal = myTransform.position;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // timer
        if (isLanded)
        {
            _waktuTerbangPeluru += Time.deltaTime;
        }
        gameManeger._waktuTerbangPeluru = this._waktuTerbangPeluru;

        myTransform.position = PosisiTerbangPeluru(_posisiAwal, _kecAwal, _waktuTerbangPeluru, _sudutTembak, _gravitasi, _sudutMeriam);

    }
    private Vector3 PosisiTerbangPeluru(Vector3 posisiAwal, float kecAwal, float waktu, float sudutTembak, float gravitasi, float sudutMeriam)
    {
        float _x = posisiAwal.x + (kecAwal * waktu * Mathf.Sin(sudutMeriam * Mathf.PI / 180));
        float _y = posisiAwal.y + ((kecAwal * waktu * Mathf.Sin(sudutTembak * Mathf.PI / 180)) - (0.5f * gravitasi * Mathf.Pow(waktu, 2)));
        float _z = posisiAwal.z + (kecAwal * waktu * Mathf.Cos(sudutMeriam * Mathf.PI / 180));

        return new Vector3(_x, _y, _z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tanah")
        {
            Destroy(this.gameObject, 2f);
            GameObject goLedakan = Instantiate(ledakan, myTransform.position, Quaternion.identity);
            Destroy(goLedakan, 3f);
            audioSource.PlayOneShot(audioLedakan);
            gameManeger._jarakTembak = Vector3.Distance(_posisiAwal, myTransform.position);
            isLanded = false;
        }
    }
}
