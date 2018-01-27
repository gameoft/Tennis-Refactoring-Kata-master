using System;

namespace Tennis
{
    public class Player
    {
        public string Name { get; set; }

        public EventHandler PlayerScored;

        public Player(string name)
        {
            this.Name = name;
        }

        public void WonPoint()
        {
            EventHandler handler = PlayerScored;
            
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public int GetCurrentScore()
        {
            return _Score;
        }

    }
    public interface IResultScoreCalculator
    {
        string GetScore(Player p1, Player p2);
    }

    public class ResultScoreCalculator : IResultScoreCalculator
    {
        private string[] PointNames = { "Love", "Fifteen", "Thirty", "Forty" };
        public string GetScore(Player p1, Player p2)
        {
            if ((p1.GetCurrentScore() < 4 && p2.GetCurrentScore() < 4)
                 && (p1.GetCurrentScore() + p2.GetCurrentScore() < 6))
            {
                return GetPartialScore(p1, p2);
            }
            else
            {
                return GetFinalScore(p1, p2);

            }
        }
        private string GetFinalScore(Player p1, Player p2)
        {
            if (p1.GetCurrentScore() == p2.GetCurrentScore())
                return "Deuce";
            string retValue = p1.GetCurrentScore() > p2.GetCurrentScore() ? p1.Name : p2.Name;
            return (1==Math.Abs(p1.GetCurrentScore() - p2.GetCurrentScore())) ? "Advantage " + retValue : "Win for " + retValue;
        }

        private string GetPartialScore(Player p1, Player p2)
        {
            string retValue = PointNames[p1.GetCurrentScore()];
            return (p1.GetCurrentScore() == p2.GetCurrentScore()) ? retValue + "-All" : retValue + "-" + PointNames[p2.GetCurrentScore()];
        }
    }

    class ObserverTabellone
    {
        private int scoreP1 { get; set; }
        private int scoreP2 { get; set; }

        private IResultScoreCalculator rsc;

        public ObserverTabellone()
        {
            rsc = new ResultScoreCalculator();
            scoreP1 = 0;
            scoreP2 = 0;
        }
        public void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Something happened to " + sender);
        }
    }

    public class TennisGame3 : ITennisGame
    {
        private Player p2;
        private Player p1;

        

        public TennisGame3(string player1Name, string player2Name)
        {
            p1 = new Player(player1Name);
            p2 = new Player(player2Name);

            ObserverTabellone tabellone = new ObserverTabellone();
            p1.PlayerScored += tabellone.HandleEvent;
            p2.PlayerScored += tabellone.HandleEvent;
            
        }
        
        public string GetScore()
        {
            return rsc.GetScore(p1, p2);
        }

        public void WonPoint(string playerName)
        {
            //if (playerName == "player1")
            //    this.p1.AddPoint();
            //else
            //    this.p2.AddPoint();
        }

    }
}

