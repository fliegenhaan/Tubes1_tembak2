using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class SiGreedy : Bot
{
    static void Main(string[] args)
    {
        new SiGreedy().Start();
    }

    SiGreedy() : base(BotInfo.FromFile("SmartGreedyBot.json")) { }

    public override void Run() 
    {
        BodyColor = Color.Red;
        TurretColor = Color.Black;
        RadarColor = Color.Red;
        BulletColor = Color.Red;
        ScanColor = Color.White;

        // Tidak ada patroli! Bot hanya akan mengejar musuh.
        while (IsRunning)
        {
            TurnGunRight(360); // Radar selalu mencari musuh
            Go();
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        Fire(3);

        // **Kejar musuh langsung tanpa perhitungan rumit**
        Forward(300); // Maju ke arah musuh
        Fire(3);

        // **Jika masih jauh, terus maju**
        Forward(400);
        Fire(3);
    }

    public override void OnHitBot(HitBotEvent e)
    {
        // **Dorong musuh lebih jauh sambil menembak!**
        Forward(500);
        Fire(3);
        Back(100); // Sedikit mundur lalu tembak lagi
        Fire(3);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        // **Mundur cepat lalu balik ke arah musuh**
        Back(150);
        TurnRight(90);
        Go();
    }
}
