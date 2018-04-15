var Match = /** @class */ (function () {
    function Match(matchData) {
        this.matchData = matchData;
        this.matchBoxRect = matchData.matchBoxRect;
        this.matchShapesContainer = new createjs.Container();
    }
    Match.prototype.draw = function (roundContainer) {
        var matchShape = new createjs.Shape();
        this.matchShapesContainer.x = this.matchBoxRect.x;
        this.matchShapesContainer.y = this.matchBoxRect.y;
        this.matchShapesContainer.addChild(matchShape);
        roundContainer.addChild(this.matchShapesContainer);
        matchShape.graphics.beginStroke("black");
        matchShape.graphics.drawRect(0, 0, this.matchBoxRect.width, this.matchBoxRect.height);
        matchShape.graphics.moveTo(0, this.matchBoxRect.height / 2).
            lineTo(this.matchBoxRect.width, this.matchBoxRect.height / 2);
        var homeTeamText = new createjs.Text(this.matchData.homeTeam, "20 px Arial", "black");
        var awayTeamText = new createjs.Text(this.matchData.awayTeam, "20 px Arial", "black");
        var homeTeamResult = new createjs.Text(this.matchData.homeTeamResult, "20 px Arial", "black");
        var awayTeamResult = new createjs.Text(this.matchData.awayTeamResult, "20 px Arial", "black");
        homeTeamText.x = this.matchBoxRect.width * 0.1;
        homeTeamText.y = this.matchBoxRect.height * 0.1;
        awayTeamText.x = this.matchBoxRect.width * 0.1;
        awayTeamText.y = this.matchBoxRect.height / 2 + this.matchBoxRect.height * 0.1;
        homeTeamResult.x = this.matchBoxRect.width * 0.9;
        homeTeamResult.y = this.matchBoxRect.height * 0.1;
        awayTeamResult.x = this.matchBoxRect.width * 0.9;
        awayTeamResult.y = this.matchBoxRect.height / 2 + this.matchBoxRect.height * 0.1;
        this.matchShapesContainer.addChild(homeTeamText);
        this.matchShapesContainer.addChild(awayTeamText);
        this.matchShapesContainer.addChild(homeTeamResult);
        this.matchShapesContainer.addChild(awayTeamResult);
    };
    return Match;
}());
//# sourceMappingURL=match.js.map