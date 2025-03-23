using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class Berserker : Bot
{
    private Random rng = new Random(); // Inisialisasi generator angka acak

    static void Main(string[] args)
    {
        new Berserker().Start(); // Memulai bot
    }

    Berserker() : base(BotInfo.FromFile("Berserker.json")) { }

    public override void Run()
    {
        // Set warna tampilan bot
        var gray = Color.FromArgb(0x80, 0x80, 0x80);
        BodyColor = gray;
        TurretColor = Color.Black;
        RadarColor = Color.White;
        ScanColor = Color.Red;
        BulletColor = Color.Black;

        while (IsRunning)
        {
            TurnGunLeft(360); // Memutar radar 360 derajat untuk mendeteksi musuh
            var move = rng.Next(0, 11); // Mengacak pergerakan bot

            SetTurnLeft(rng.Next(70, 120)); // Mengubah arah bot secara acak
            
            // Menentukan apakah bot maju atau mundur
            if (move > 5)
            {
                SetForward(rng.Next(450, 700)); // Maju sejauh nilai acak
            }
            else if (move > 0)
            {
                SetBack(rng.Next(450, 700)); // Mundur sejauh nilai acak
            }
            else
            {
                SetBack(0); // Tidak bergerak
            }
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        var distance = DistanceTo(e.X, e.Y); // Menghitung jarak ke musuh
        
        // Menentukan kekuatan tembakan berdasarkan jarak dan energi
        if (distance < 180 && Energy > 50)
        {
            Fire(3); // Menembak dengan kekuatan maksimal jika musuh dekat dan energi cukup
        }
        else if (distance < 280 && Energy > 20)
        {
            Fire(1.5); // Menembak dengan kekuatan sedang jika musuh dalam jarak menengah
        }
        else if (Energy > 1)
        {
            Fire(1); // Menembak dengan kekuatan minimal jika energi masih tersedia
        }
        else
        {
            var Firepower = Energy * 0.5; // Menghitung tembakan berdasarkan sisa energi
            Fire(Firepower);
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e)
    {
        // Saat terkena peluru, bot akan mundur dan berputar secara acak untuk menghindar
        SetBack(rng.Next(100, 150)); // Mundur sejauh nilai acak
        SetTurnRight(rng.Next(75, 90)); // Berputar ke kanan secara acak
    }
    
    public override void OnHitWall(HitWallEvent e)
    {
        // Jika menabrak dinding, bot akan mundur dan mengubah arah
        SetBack(100);
        SetTurnRight(200); // Berputar ke kanan 200 derajat
        TurnGunRight(200); // Memutar turret ke kanan untuk mencari musuh
    }

    public override void OnHitBot(HitBotEvent e)
    {
        // Jika bertabrakan dengan bot lain, mundur dan memutar turret untuk menargetkan musuh
        SetBack(rng.Next(100, 200)); // Mundur sejauh nilai acak
        TurnGunRight(200); // Memutar turret ke kanan untuk menembak musuh
    }
}
