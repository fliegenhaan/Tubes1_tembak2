using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;


public class Berserker : Bot
{
    private Random rng = new Random();

    static void Main(string[] args)
    {
        new Berserker().Start();
    }

    Berserker() : base(BotInfo.FromFile("Berserker.json")) { }

    public override void Run()
    {
        // Set warna
        var gray = Color.FromArgb(0x80, 0x80, 0x80);
        BodyColor = gray;
        TurretColor = Color.Black;
        RadarColor = Color.White;
        ScanColor = Color.Red;
        BulletColor = Color.Black;

        while (IsRunning)
        {
            TurnGunLeft(360); // Radar selalu scanning
            if (Energy > 20)
            {
                SetForward(rng.Next(1000, 2000));
            }
            else
            {
                SetBack(rng.Next(1000,1200));
                SetTurnLeft(rng.Next(90, 200));
                SetForward(rng.Next(1000,1200));
                SetTurnRight(rng.Next(90, 200));
            }
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        var distance = DistanceTo(e.X, e.Y);
        if (distance < 200 && Energy > 50) {
            Fire(1.5);
        }
        else
        {
            Fire(1);
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e) {
        // define movement by attack energy
        SetBack(rng.Next(100, 150));
        SetTurnRight(rng.Next(60, 90));

    }
    public override void OnHitWall(HitWallEvent e)
    {
        SetBack(100);
        SetTurnLeft(200);
    }

    public override void OnHitBot(HitBotEvent e)
    {
        SetBack(rng.Next(500,800));
    }

}
