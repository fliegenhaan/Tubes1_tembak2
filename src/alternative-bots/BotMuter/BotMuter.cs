using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

// Modification from templatebot
public class BotMuter : Bot
{
    // The main method starts our bot
    static void Main(string[] args)
    {
        new BotMuter().Start();
    }

    // Constructor, which loads the bot config file
    BotMuter() : base(BotInfo.FromFile("BotMuter.json")) { }

    // Called when a new round is started -> initialize and do some movement
    public override void Run()
    {

        BodyColor = Color.FromArgb(0xFF, 0x8C, 0x00);
        TurretColor = Color.FromArgb(0xFF, 0xA5, 0x00);
        RadarColor = Color.FromArgb(0xFF, 0xD7, 0x00);
        BulletColor = Color.FromArgb(0xFF, 0x45, 0x00);
        ScanColor = Color.FromArgb(0xFF, 0xFF, 0x00);
        TracksColor = Color.FromArgb(0x99, 0x33, 0x00);
        GunColor = Color.FromArgb(0xCC, 0x55, 0x00);

        // Repeat while the bot is running
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

    // We saw another bot -> fire!
    public override void OnScannedBot(ScannedBotEvent evt)
    {
        Fire(3);
    }

    // We were hit by a bullet -> turn perpendicular to the bullet
    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        // Calculate the bearing to the direction of the bullet
        var bearing = CalcBearing(evt.Bullet.Direction);

        // Turn 90 degrees to the bullet direction based on the bearing
        TurnLeft(90 - bearing);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        TurnRight(180);
        Forward(200);
    }


}

