using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class BotMuter : Bot
{
    static void Main(string[] args)
    {
        new BotMuter().Start();
    }
    BotMuter() : base(BotInfo.FromFile("BotMuter.json")) { }

    public override void Run()
    {

        BodyColor = Color.FromArgb(0xFF, 0x8C, 0x00);
        TurretColor = Color.FromArgb(0xFF, 0xA5, 0x00);
        RadarColor = Color.FromArgb(0xFF, 0xD7, 0x00);
        BulletColor = Color.FromArgb(0xFF, 0x45, 0x00);
        ScanColor = Color.FromArgb(0xFF, 0xFF, 0x00);
        TracksColor = Color.FromArgb(0x99, 0x33, 0x00);
        GunColor = Color.FromArgb(0xCC, 0x55, 0x00);

        while (IsRunning)
        {
            Forward(100);
            TurnGunRight(135);
            TurnRight(72);
            TurnGunRight(135);
            Forward(100);
            TurnRight(72);
            TurnGunRight(135);
            Forward(100);
            TurnRight(72);
            TurnGunRight(135);
            Forward(100);
            TurnRight(72);
            TurnGunRight(135);
            Forward(100);
            TurnRight(72);
            TurnGunRight(135);
            TurnRight(72);
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(3);
    }

    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        var bearing = CalcBearing(evt.Bullet.Direction);

        TurnLeft(90 - bearing);
        Forward(120);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        TurnRight(120);
        Forward(200);
    }

}

