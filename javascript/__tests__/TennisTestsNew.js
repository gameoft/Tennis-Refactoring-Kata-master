describe("Hello World Server", function() {

});

describe('JavaScript addition operator', function () {
    it('adds two numbers together', function () {
        expect(1 + 2).toEqual(3);
    });
});

describe('TennisGame', function () {
    it('Can instantiate TennisGame1', function () {
        var game = new TennisGame1("player1", "player2");

        expect(game).not.toBe(null);
    });
});