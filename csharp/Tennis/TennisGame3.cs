using System;

namespace Tennis
{

    public interface IResultScoreCalculator
    {
        string GetScore(int p1, int p2);
    }

    public class ResultScoreCalculator : IResultScoreCalculator
    {
        private string[] PointNames = { "Love", "Fifteen", "Thirty", "Forty" };
        public string _p1name { get; set; }
        public string _p2name { get; set; }
        public ResultScoreCalculator(string p1name, string p2name)
        {
            _p1name = p1name;
            _p2name = p2name;
        }
        public string GetScore(int p1, int p2)
        {
            if ((p1 < 4 && p2 < 4)
                 && (p1 + p2 < 6))
            {
                return GetPartialScore(p1, p2);
            }
            else
            {
                return GetFinalScore(p1, p2);

            }
        }
        private string GetFinalScore(int p1, int p2)
        {
            if (p1 == p2)
                return "Deuce";
            string retValue = p1 > p2 ? _p1name : _p2name;
            return (1 == Math.Abs(p1 - p2)) ? "Advantage " + retValue : "Win for " + retValue;
        }

        private string GetPartialScore(int p1, int p2)
        {
            string retValue = PointNames[p1];
            return (p1 == p2) ? retValue + "-All" : retValue + "-" + PointNames[p2];
        }
    }

        public class ObservablePlayer
    {
        public string Name { get; set; }

        public EventHandler Player1Scored;
        public EventHandler Player2Scored;

        public ObservablePlayer(string name)
        {
            this.Name = name;
        }

        public void Player1ScoredOnePoint()
        {
            EventHandler handler = Player1Scored;
            
            if (handler != null)
                handler(this, EventArgs.Empty);
            
        }
        public void Player2ScoredOnePoint()
        {
            EventHandler handler = Player2Scored;

            if (handler != null)
                handler(this, EventArgs.Empty);
            
        }
        

    }
 

    class ObserverTabellone
    {
        private string _P1Name { get; set; }
        private string _P2Name { get; set; }

        private int scoreP1 { get; set; }
        private int scoreP2 { get; set; }

        private IResultScoreCalculator rsc;

        public ObserverTabellone(string P1Name, string P2Name)
        {
            scoreP1 = 0;
            scoreP2 = 0;
           _P1Name = P1Name;
           _P2Name = P2Name;
            rsc = new ResultScoreCalculator(_P1Name, _P2Name);

        }

        public void Player1ScoredOnePoint(object sender, EventArgs args)
        {
            scoreP1++;
        }
        public void Player2ScoredOnePoint(object sender, EventArgs args)
        {
            scoreP2++;
        }
        public string GetCurrentScore()
        {
            return rsc.GetScore(scoreP1, scoreP2);
        }
    }

    public class TennisGame3 : ITennisGame
    {
        private ObservablePlayer p2;
        private ObservablePlayer p1;
        private ObserverTabellone tabellone;

        public TennisGame3(string player1Name, string player2Name)
        {
            p1 = new ObservablePlayer(player1Name);
            p2 = new ObservablePlayer(player2Name);

            tabellone = new ObserverTabellone(p1.Name, p2.Name);
            p1.Player1Scored += tabellone.Player1ScoredOnePoint;
            p2.Player2Scored += tabellone.Player2ScoredOnePoint;
            
        }
        
        public string GetScore()
        {
            return tabellone.GetCurrentScore();
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.p1.Player1ScoredOnePoint();
            else
                this.p2.Player2ScoredOnePoint();
        }

    }
}

