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
            $("#university").autocomplete({
                source: data,
                minLength: 2,
                select: function (event, ui) {
                    $("#university").val(ui.item.id);
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
        maxDate: maxDate
    });
    $.datepicker.setDefaults($.datepicker.regional['ua']);
    $(".date-picker").datepicker('setDate', null);
    $("#chkbGamer").click(function () {
        if ($(this).is(':checked')) {
            $("#gamerFields").show();
        }
        else {
            $("#gamerFields").hide();
        }
    });
    $("#chkbMiddleName").click(function () {
        if ($(this).is(':checked')) {
            $("#middleName").hide();
        }
        else {
            $("#middleName").show();
        }
    });
    $("#chkbPersonal").click(function () {
        if ($(this).is(':checked')) {
            $(':input[type="submit"]').prop('disabled', false);
        }
        else {
            $(':input[type="submit"]').prop('disabled', true);
        }
    });
});