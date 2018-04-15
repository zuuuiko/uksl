var Round = /** @class */ (function () {
    function Round(roundData) {
        this.roundData = roundData;
        this.roundShapesContainer = new createjs.Container();
        this.matches = [];
    }
    Round.prototype.draw = function (stage, roundBoxRect) {
        var roundShape = new createjs.Shape();
        this.roundShapesContainer.addChild(roundShape);
        this.roundShapesContainer.x = roundBoxRect.x;
        roundShape.graphics.beginStroke("black").drawRect(0, 0, roundBoxRect.width, roundBoxRect.height);
        this.roundShapesContainer.setBounds(roundBoxRect.x, roundBoxRect.y, roundBoxRect.width, roundBoxRect.height);
        stage.addChild(this.roundShapesContainer);
        this.drawMatches();
    };
    Round.prototype.drawMatches = function () {
        for (var _i = 0, _a = this.roundData.matches; _i < _a.length; _i++) {
            var matchData = _a[_i];
            var match = new Match(matchData);
            match.draw(this.roundShapesContainer);
            this.matches.push(match);
        }
    };
    return Round;
}());
//# sourceMappingURL=round.js.map