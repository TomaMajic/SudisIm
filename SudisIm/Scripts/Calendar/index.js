$(document).ready(function () {
    var dateFormat = "hh:mm:ss";
    $('#calendar').fullCalendar({
        locale: 'hr',
        events: calendarEvents,
        eventClick: function (event, jsEvent, view) {
            if (event.isGame)
                alert(moment(event.start).format(dateFormat) + " \n" + event.location);
        }
    });

});