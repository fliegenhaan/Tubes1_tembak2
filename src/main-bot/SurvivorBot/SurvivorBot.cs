using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class SurvivorBot : Bot
{
    private Random rng = new Random();
    private bool movingForward = true;

    static void Main() {
        new SurvivorBot().Start();
    }

    SurvivorBot() : base(BotInfo.FromFile("SurvivorBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.DarkGreen;
        TurretColor = Color.Red;
        RadarColor = Color.Yellow;
        BulletColor = Color.White;
        ScanColor = Color.Magenta;

        while (IsRunning)
        {
            if (movingForward)
            {
                SetForward(rng.Next(800, 1600));
                SetTurnRight(rng.Next(30, 90));
            }
            else
            {
                SetBack(rng.Next(800, 1600));
                SetTurnRight(rng.Next(30, 90));
            }

            TurnGunLeft(180);
            TurnGunRight(180);
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        double distance = DistanceTo(e.X, e.Y);
        double firePower = distance < 200 ? 3 : (distance < 500 ? 2 : 1);

        // Jika energi masih tinggi, langsung tembak (greedy)
        if (Energy > 30 || distance < 200)
        {
            Fire(firePower);
        }
        else if (Energy > 10)
        {
            Fire(0.5); // Masih bisa menembak
        }
        else
        {
            SetTurnRight(rng.Next(60, 120));
            SetBack(300); 
        }

    }

    public override void OnHitWall(HitWallEvent e)
    {
        // Menghindar dari tembok
        Back(100);
        SetTurnRight(rng.Next(80, 120));
    }

    public override void OnHitBot(HitBotEvent e)
    {
        // Jika nabrak musuh, mundur dan tetap greedy menyerang
        if (e.IsRammed)
        {
            Back(150);
            SetTurnRight(rng.Next(90, 180));
            Fire(3);
        }
        else
        {
            Fire(2);
        }
    }
}