$(function () {
    $.ajax({
        url: "../Content/data/vuz.json",
        dataType: "json",
        success: function (xmlResponse) {
            var data = $.map(xmlResponse, function (item) {
                return {
                    value: item.UniversityShortName,
                    id: item.UniversityId
                };
            });
            var univer = data.find(function (el) {
                return el.id == $("#UniversityId").val();
            });
            if (univer)
                $("#UniversityName").val(univer.value);
            $("#UniversityName").autocomplete({
                source: data,
                minLength: 2,
                select: function (event, ui) {
                    $("#UniversityId").val(ui.item.id);
                }
            });
        }
    });

    var maxDate = new Date();
    maxDate.setFullYear(maxDate.getFullYear() - 16);
    $.datepicker.regional['ua'] = {
        monthNames: ['січня', 'лютого', 'березня', 'квітня', 'травня', 'червня',
            'липня', 'серпня', 'вересня', 'жовтня', 'листопада', 'грудня'],
        //monthNames: ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Червень',
        //    'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'],
        monthNamesShort: ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Липень',
            'Червень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'],
        //monthStatus: 'Voir un autre mois', yearStatus: 'Voir un autre année',
        //weekHeader: 'Sm', weekStatus: '',
        dayNames: ['Неділя', 'Понеділок', 'Вівторок', 'Середа', 'Четвер', "П'ятниця", 'Субота'],
        dayNamesShort: ['Нед', 'Пон', 'Вівт', 'Сер', 'Чтв', 'Птн', 'Суб'],
        dayNamesMin: ['Нд', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        dateFormat: 'dd MM yy року', firstDay: 1
    };
    $(".date-picker").datepicker({
        showAnim: "clip",
        changeMonth: true,
        changeYear: true,
        showOtherMonths: true,
        selectOtherMonths: true,
        maxDate: maxDate,
        onSelect: function (dateText, inst) {
            $("#BirthDate").val(inst.selectedDay + '/' + (inst.selectedMonth + 1) +  '/' + inst.selectedYear);
            //console.dir(inst.selectedDay + '/' + (inst.selectedMonth + 1) + '/' + inst.selectedYear);
        }
    });
    $.datepicker.setDefaults($.datepicker.regional['ua']);
    var bd = $("#BirthDate").val();
    if (bd) {
        var temp = bd.split(".");
        bd = new Date(temp[2].slice(0, 4), temp[1] - 1, temp[0]);
    }
    $(".date-picker").datepicker('setDate', bd);

    //var gamerInputs = $('#gamerFields input')
    //    .not(':input[type=hidden], :input[type=checkbox]');
    ////$(gamerInputs).each(function () {
    ////    this.required = false;
    ////});
    //$("#chkbGamer").click(function () {
    //    if ($(this).is(':checked')) {
    //        $(gamerInputs).each(function () {
    //            this.required = true;
    //        });
    //        $("#gamerFields").show();
    //    }
    //    else {
    //        $(gamerInputs).each(function () {
    //            this.required = false;
    //        });
    //        $("#gamerFields").hide();
    //    }
    //});
    if ($("#MiddleName").val()) {
        //$("#middleName input").prop('required', false);
        $("#middleName").show();
        $("#chkbMiddleName").prop("checked", false);
    }
    else {
        //$("#middleName input").prop('required', true);
        $("#middleName").hide();
        $("#chkbMiddleName").prop("checked", true);
    }
    $("#chkbMiddleName").click(function () {
        if ($(this).is(':checked')) {
            //$("#middleName input").prop('required', false);
            $("#middleName").hide();
        }
        else {
            //$("#middleName input").prop('required', true);
            $("#middleName").show();
        }
    });
    //$("#chkbPersonal").click(function () {
    //    if ($(this).is(':checked')) {
    //        $($('input')
    //            .not(':input[type=submit], :input[type=hidden], :input[type=checkbox]')).each(function () {
    //                console.log(this.name + ' - ' + this.required);
    //            });
    //        $(':input[type="submit"]').prop('disabled', false);
    //    }
    //    else {
    //        $(':input[type="submit"]').prop('disabled', true);
    //    }
    //});
});