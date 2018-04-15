$(function () {
    //$("#tabs").tabs().addClass("ui-tabs-vertical ui-helper-clearfix");
    $("#tournament-tabs").tabs({
        active: 0,
        //show: { effect: "explode", duration: 1000 },
        activate: function (event, ui) {
            var canv = document.createElement("canvas");
            canv.width = 600;
            canv.height = 400;
            var regionId;
            if (ui.newTab.index() == 0) {
                $(".university-list").show();
                var tournamentRegionId = localStorage["tournamentRegionId"];
                if (tournamentRegionId) {
                    regionId = tournamentRegionId;
                }
                else {
                    var ctx = canv.getContext('2d');
                    ctx.font = "48px serif";
                    var text = "<- Оберіть Ваш регіон!";
                    ctx.fillText(text, 10, 50);
                }
            }
            else {
                $(".university-list").hide();
                regionId = 1;
            }
            if (regionId) {
                $.ajax({
                    type: "GET",
                    url: "/api/UcslApi/GetTournamentData",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: {
                        tournamentId: $("#tournament-tabs").data("tournament"),
                        stage: ui.newTab.index() + 1,
                        regionId: regionId
                    },
                    success: function (data) {
                        console.log(JSON.stringify(data));
                        console.dir(data);
                        if (data) {
                            var drawer = new Drawer(canv, data);
                            drawer.drawSingleElimination();
                        }
                    }
                });
            }
            ui.newPanel.empty();
            $(canv).appendTo(ui.newPanel);
            //ui.jqXHR.fail(function () {
            //    ui.panel.html(
            //        "Couldn't load this tab. We'll try to fix this as soon as possible. ");
            //});
        }
    });
    $("#tournament-tabs").tabs("option", "active", 1);
    $("#tournament-tabs").tabs("option", "active", 0);
    //function refresh1 () {
    //    var canv = document.createElement("canvas");
    //    canv.width = 600;
    //    canv.height = 500;
    //    var ctx = canv.getContext('2d');
    //    ctx.font = "48px serif";
    //    //ui.newPanel.empty();
    //    var tRegion = localStorage["tournamentRegion"];
    //    var text;
    //    if (tRegion) {
    //        text = JSON.parse(tRegion).regionName;
    //    }
    //    else {
    //        text = "<- Оберіть Ваш університет!";
    //    }
    //    ctx.fillText(text, 10, 50);
    //    $(canv).appendTo($("#stage1"));
    //};
    //refresh1();
        //.addClass("ui-tabs-vertical ui-helper-clearfix");
    //$("#tournament-tabs li").removeClass("ui-corner-top").addClass("ui-corner-left");
    $.ajax({
        type: "GET",
        url: "/api/UcslApi/GetTournamentRegions",
        contentType: "application/json; charset=utf-8",
        data: {
            tournamnetId: $("#tournament-tabs").data("tournament")
        },
        dataType: "json",  
        success: function (data) {
            var div = $(".university-list-body");
            $.each(data, function (i, item) {
                var p = document.createElement("p");
                p.id = item.Id;
                p.innerHTML = item.Name;
                p.addEventListener("click", function () {
                    localStorage["tournamentRegionId"] = item.Id;
                    $("#tournament-tabs").tabs("option", "active", 1);
                    $("#tournament-tabs").tabs("option", "active", 0);
                });
                div.append(p);
            });
        }
    });
});