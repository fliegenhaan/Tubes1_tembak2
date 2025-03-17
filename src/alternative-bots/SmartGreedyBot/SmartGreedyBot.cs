using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class SiPintar : Bot
{
    static void Main(string[] args)
    {
        new SiPintar().Start();
    }

    SiPintar() : base(BotInfo.FromFile("SmartGreedyBot.json")) { }

    public override void Run() 
    {
        BodyColor = Color.Green;
        TurretColor = Color.Gray;
        RadarColor = Color.Yellow;
        BulletColor = Color.Green;
        ScanColor = Color.Red;

        // Bot akan terus bergerak dalam pola 3/4 arena sambil memindai
        while (IsRunning)
        {
            ExecutePatrolling();
            TurnRadarRight(360); // Scan 360 derajat sambil berjalan
            Go(); 
        }
    }

    private void ExecutePatrolling()
    {
        // Gerakan patroli secara dinamis
        Forward(150);
        TurnRight(45);
        Forward(100);
        TurnLeft(90);
        Forward(120);
        TurnRight(60);
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        double distance = DistanceTo(e.X, e.Y);
        double gunBearing = NormalizeRelativeAngle(DirectionTo(e.X, e.Y) - GunDirection);

        TurnGunLeft(gunBearing);
        
        // Sesuaikan power tembakan berdasarkan jarak musuh
        double firePower = (distance < 200) ? 3 : (distance < 400) ? 2 : 1;
        Fire(firePower);
    }

    public override void OnHitBot(HitBotEvent e)
    {
        double gunBearing = NormalizeRelativeAngle(DirectionTo(e.X, e.Y) - GunDirection);
        TurnGunLeft(gunBearing);
        Fire(3); // Maksimal damage jika bertabrakan

        // Hindari musuh dengan mundur dan belok
        Back(50);
        TurnRight(45);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        // Jika menabrak dinding, mundur sedikit lalu berputar
        Back(50);
        TurnRight(90);
        Go();
    }
}
