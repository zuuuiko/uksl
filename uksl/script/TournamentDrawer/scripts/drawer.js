var Drawer = /** @class */ (function () {
    function Drawer(canvas, inputData) {
        this.canvas = canvas;
        this.stage = new createjs.Stage(canvas);
        this.inputData = inputData;
        this.rounds = [];
    }
    Drawer.prototype.drawSingleElimination = function () {
        var roundBoxRect = this.calculateRoundBoxRect(this.inputData.group.rounds.length);
        // For matchBoxRect calculation we rely on the order of rounds in the input JSON
        var matchBoxRect = this.calculateMatchBoxRect(roundBoxRect, this.inputData.group.rounds[0].matches.length);
        this.calculateMatchRects(roundBoxRect);
        // Draw rounds and matches
        for (var _i = 0, _a = this.inputData.group.rounds; _i < _a.length; _i++) {
            var roundData = _a[_i];
            var round = new Round(roundData);
            round.draw(this.stage, roundBoxRect);
            this.rounds.push(round);
            roundBoxRect.x += roundBoxRect.width;
        }
        this.drawConnectors();
        this.stage.update();
    };
    Drawer.prototype.drawConnectors = function () {
        var connectorsShape = new createjs.Shape();
        this.stage.addChild(connectorsShape);
        connectorsShape.setBounds(0, 0, this.canvas.width, this.canvas.height);
        for (var i in this.rounds) {
            if (Number(i) < this.rounds.length - 1) {
                var previousRound = this.rounds[i];
                var nextRound = this.rounds[Number(i) + 1];
                // Get 2 matches from current round and 1 match from next round
                for (var nextMatchIndex in nextRound.matches) {
                    var previousMatch_1_Index = Number(nextMatchIndex) * 2;
                    var previousMatch_2_Index = previousMatch_1_Index + 1;
                    var nextMatch = nextRound.matches[nextMatchIndex];
                    var previousMatch_1 = previousRound.matches[previousMatch_1_Index];
                    var previousMatch_2 = previousRound.matches[previousMatch_2_Index];
                    var moveToPoint_1 = previousRound.roundShapesContainer.localToGlobal(previousMatch_1.matchBoxRect.x + previousMatch_1.matchBoxRect.width, previousMatch_1.matchBoxRect.y + previousMatch_1.matchBoxRect.height / 2);
                    var point_2 = previousRound.roundShapesContainer.localToGlobal((previousMatch_1.matchBoxRect.x + previousMatch_1.matchBoxRect.width) + (previousRound.roundShapesContainer.getBounds().width - (previousMatch_1.matchBoxRect.x + previousMatch_1.matchBoxRect.width)) / 2, previousMatch_1.matchBoxRect.y + previousMatch_1.matchBoxRect.height / 2);
                    var point_3 = previousRound.roundShapesContainer.localToGlobal((previousMatch_2.matchBoxRect.x + previousMatch_2.matchBoxRect.width) + (previousRound.roundShapesContainer.getBounds().width - (previousMatch_2.matchBoxRect.x + previousMatch_2.matchBoxRect.width)) / 2, previousMatch_2.matchBoxRect.y + previousMatch_2.matchBoxRect.height / 2);
                    var point_4 = previousRound.roundShapesContainer.localToGlobal(previousMatch_2.matchBoxRect.x + previousMatch_2.matchBoxRect.width, previousMatch_2.matchBoxRect.y + previousMatch_2.matchBoxRect.height / 2);
                    var moveToPoint_2 = previousRound.roundShapesContainer.localToGlobal((previousMatch_1.matchBoxRect.x + previousMatch_1.matchBoxRect.width) + (previousRound.roundShapesContainer.getBounds().width - (previousMatch_1.matchBoxRect.x + previousMatch_1.matchBoxRect.width)) / 2, point_2.y + (point_3.y - point_2.y) / 2);
                    var finalPoint = nextRound.roundShapesContainer.localToGlobal(nextMatch.matchBoxRect.x, nextMatch.matchBoxRect.y + nextMatch.matchBoxRect.height / 2);
                    //console.log(moveToPoint_1, point_2, point_3, point_4, moveToPoint_2, finalPoint);
                    connectorsShape.graphics.setStrokeStyle(1).beginStroke("black").
                        moveTo(moveToPoint_1.x, moveToPoint_1.y).
                        lineTo(point_2.x, point_2.y).lineTo(point_3.x, point_3.y).lineTo(point_4.x, point_4.y).
                        moveTo(moveToPoint_2.x, moveToPoint_2.y).lineTo(finalPoint.x, finalPoint.y);
                }
            }
        }
    };
    Drawer.prototype.calculateMatchBoxRect = function (roundBoxRect, matchesCount) {
        var matchBoxWidth = roundBoxRect.width / 3 * 2;
        var matchBoxHeight = roundBoxRect.height * 0.67 / matchesCount;
        return new createjs.Rectangle(0, 0, matchBoxWidth, matchBoxHeight);
    };
    Drawer.prototype.calculateRoundBoxRect = function (roundsCount) {
        return new createjs.Rectangle(0, 0, this.canvas.width / roundsCount, this.canvas.height);
    };
    Drawer.prototype.calculateVerticalGapMatchBoxForFirstRound = function (roundHeight, matchBoxHeight, firstRoundMatchesCount) {
        return (roundHeight - matchBoxHeight * firstRoundMatchesCount) / (firstRoundMatchesCount + 1);
    };
    Drawer.prototype.calculateMatchRects = function (roundBoxRect) {
        var matchBoxRect = this.calculateMatchBoxRect(roundBoxRect, this.inputData.group.rounds[0].matches.length);
        // Calculate Match Box Rects for 1st round
        var verticalGapMatchBoxForFirstRound = this.calculateVerticalGapMatchBoxForFirstRound(roundBoxRect.height, matchBoxRect.height, this.inputData.group.rounds[0].matches.length);
        var x = (roundBoxRect.width - matchBoxRect.width) / 2;
        var yForFirstRound = verticalGapMatchBoxForFirstRound;
        for (var _i = 0, _a = this.inputData.group.rounds[0].matches; _i < _a.length; _i++) {
            var matchData = _a[_i];
            matchData.matchBoxRect = new createjs.Rectangle(x, yForFirstRound, matchBoxRect.width, matchBoxRect.height);
            yForFirstRound += matchBoxRect.height + verticalGapMatchBoxForFirstRound;
        }
        for (var i in this.inputData.group.rounds) {
            if (Number(i) < this.inputData.group.rounds.length - 1) {
                var previousRound = this.inputData.group.rounds[i];
                var nextRound = this.inputData.group.rounds[Number(i) + 1];
                // Get 2 matches from current round and 1 match from next round
                for (var nextMatchIndex in nextRound.matches) {
                    var previousMatch_1_Index = Number(nextMatchIndex) * 2;
                    var previousMatch_2_Index = previousMatch_1_Index + 1;
                    var nextMatch = nextRound.matches[nextMatchIndex];
                    var previousMatch_1 = previousRound.matches[previousMatch_1_Index];
                    var previousMatch_2 = previousRound.matches[previousMatch_2_Index];
                    nextMatch.matchBoxRect = new createjs.Rectangle(x, (previousMatch_1.matchBoxRect.y + previousMatch_1.matchBoxRect.height / 2) +
                        ((previousMatch_2.matchBoxRect.y + previousMatch_2.matchBoxRect.height / 2) - (previousMatch_1.matchBoxRect.y + previousMatch_1.matchBoxRect.height / 2)) / 2 -
                        matchBoxRect.height / 2, matchBoxRect.width, matchBoxRect.height);
                }
            }
        }
    };
    return Drawer;
}());
//# sourceMappingURL=drawer.js.map