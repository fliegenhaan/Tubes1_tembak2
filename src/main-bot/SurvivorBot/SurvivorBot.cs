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
            // Gerakan acak untuk menghindari serangan lawan
            if (movingForward)
            {
                SetForward(rng.Next(100, 400));
            }
            else
            {
                SetBack(rng.Next(100, 400));
            }

            // Rotasi acak agar susah ditembak
            SetTurnRight(rng.Next(30, 90));
            WaitFor(new TurnCompleteCondition(this));
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
        else
        {
            // Kalau energi rendah,  menghindar dari pertempuran
            SetTurnRight(rng.Next(60, 120));
            SetBack(200);
        }
    }

    public override void OnHitWall(HitWallEvent e)
    {
        // Menghindar dari tembok
        Back(50);
        SetTurnRight(rng.Next(80, 120));
    }

    public override void OnHitBot(HitBotEvent e)
    {
        // Jika nabrak musuh, mundur dan tetap greedy menyerang
        if (e.IsRammed)
        {
            Back(100);
            Fire(3);
        }
        else
        {
            Fire(2);
        }
    }
}

public class TurnCompleteCondition : Condition
{
    private readonly Bot bot;
    public TurnCompleteCondition(Bot bot) { this.bot = bot; }
    public override bool Test() { return bot.TurnRemaining == 0; }
}
