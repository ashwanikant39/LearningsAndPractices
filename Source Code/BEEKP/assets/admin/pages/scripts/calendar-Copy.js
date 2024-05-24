var Calendar = function() {


    return {
        //main function to initiate the module
        init: function() {
            Calendar.initCalendar();
        },

        initCalendar: function() {

            if (!jQuery().fullCalendar) {
                return;
            }
			
			var cfd = Date.parse('01/01/2017');
			var date = new Date(cfd); 


            //var date = new Date('');
			//var date = Date.parse('19/12/2017 03:58 PM'); 
			//alert(date);
			//var date = new Date(Date.parse("03/20/2012","MM/dd/yyyy"));
			alert(date);
			//var date = Date.parse('2010-10-18, 10:06 AM');
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            var h = {};

            if (Metronic.isRTL()) {
                if ($('#calendar').parents(".portlet").width() <= 720) {
                    $('#calendar').addClass("mobile");
                    h = {
                        right: 'title, prev, next',
                        center: '',
                       // left: 'agendaDay, agendaWeek, month, today'
					    left: 'month, today'
                    };
                } else {
                    $('#calendar').removeClass("mobile");
                    h = {
                        right: 'title',
                        center: '',
                        //left: 'agendaDay, agendaWeek, month, today, prev,next'
						left: 'month, today, prev,next'
                    };
                }
            } else {
                if ($('#calendar').parents(".portlet").width() <= 720) {
                    $('#calendar').addClass("mobile");
                    h = {
                        left: 'title, prev, next',
                        center: '',
                        //right: 'today,month,agendaWeek,agendaDay'
						right: 'today,month'
                    };
                } else {
                    $('#calendar').removeClass("mobile");
                    h = {
                        left: 'title',
                        center: '',
                        //right: 'prev,next,today,month,agendaWeek,agendaDay'
						right: 'prev,next,today,month'
                    };
                }
            }       
          

            $('#calendar').fullCalendar('destroy'); // destroy the calendar
            $('#calendar').fullCalendar({ //re-initialize the calendar
                header: h,
                defaultView: 'month', // change default view with available options from http://arshaw.com/fullcalendar/docs/views/Available_Views/ 
                slotMinutes: 15,
                editable: true,
                droppable: true, // this allows things to be dropped onto the calendar !!!
           
				events: function(start, end, timezone, callback) {
					$.ajax({
						url: 'myxmlfeed.php',
						dataType: 'xml',
						data: {
							// our hypothetical feed requires UNIX timestamps
							start: start.unix(),
							end: end.unix()
						},
						success: function(doc) {
							var events = [];
							$(doc).find('event').each(function() {
								events.push({
									title: $(this).attr('title'),
									start: $(this).attr('start') // will be parsed
								});
							});
							callback(events);
						}
					});
				}

            });

        }

    };

}();