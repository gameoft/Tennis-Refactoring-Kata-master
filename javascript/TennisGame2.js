var TennisGame2 = function(player1Name, player2Name) {
    this.P1point = 0;
    this.P2point = 0;
};

TennisGame2.prototype.PointNames = ["Love","Fifteen","Thirty", "Forty"];

TennisGame2.prototype.getScore = function() {
    var score = "";

    var diffPoints = Math.abs(this.P2point - this.P1point);

    if (diffPoints === 0) {
        score = Math.max( this.P1point,this.P2point) > 2 ?
            "Deuce" :
            this.PointNames[this.P1point] + "-All";
    }else{
        if(Math.max( this.P1point,this.P2point) > 3){
            //vantaggi o win
            var suffix = diffPoints > 1 ? "Win for " : "Advantage ";
            score = this.P1point > this.P2point ? suffix + "player1" : suffix + "player2";

        }else{
            score = this.PointNames[this.P1point] + "-" + this.PointNames[this.P2point];
        }
    }
   
    return score;
};

TennisGame2.prototype.P1Score = function() {
     this.P1point++;
};

TennisGame2.prototype.P2Score = function() {
    this.P2point++;
};

TennisGame2.prototype.wonPoint = function(player) {
    if (player === "player1")
        this.P1Score();
    else
        this.P2Score();
};

if (typeof window === "undefined") {
    module.exports = TennisGame2;
}