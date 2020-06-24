using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManegerScript : MonoBehaviour
{
    public GameObject go_sudutMeriam;
    public GameObject go_sudutTembak;
    public GameObject go_kecepatanAwal;
    public GameObject go_gravitasi;
    public GameObject go_jarak;
    public GameObject go_waktuTerbang;

    public GameObject _torque;
    public GameObject _selongsong;

    public float _waktuTerbangPeluru;
    public float _jarakTembak;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        go_sudutMeriam.GetComponent<Text>().text = ": " + _torque.GetComponent<TankBehaviorScript>().sudutMeriam.ToString() + " derajat";
        go_sudutTembak.GetComponent<Text>().text = ": " + _torque.GetComponent<TankBehaviorScript>().nilaiRotasiY.ToString() + " derajat";
        go_gravitasi.GetComponent<Text>().text = ": " + _torque.GetComponent<TankBehaviorScript>().gravitasi.ToString() + " m/s2";
        go_kecepatanAwal.GetComponent<Text>().text = ": " + _torque.GetComponent<TankBehaviorScript>().kecepatanAwalPeluru.ToString() + " m/s";

        go_waktuTerbang.GetComponent<Text>().text = ": " + _waktuTerbangPeluru.ToString() + " detik";
        go_jarak.GetComponent<Text>().text = ": " + _jarakTembak.ToString() + " meter";
    }
}
