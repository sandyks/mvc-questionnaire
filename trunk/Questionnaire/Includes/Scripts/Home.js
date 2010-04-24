Questionnaire.Home = {};
Questionnaire.Home.Index =
	function() {
	    var buttonSubmit = $('INPUT[type="button"]');
	    buttonSubmit.click(
			function() {
			    $(this).attr('disabled', 'disabled');
			    var numberOfCorrect = 0;
			    var numberOfIncorrect = 0;
			    $.each(
					$('FORM'),
					function() {
					    var question = $(this).find('DIV');
					    $.ajax(
							{
							    async: false,
							    data: $(this).serialize(),
							    type: 'POST',
							    url: appUrl + 'Question.mvc/Validate',
							    success:
									function(result) {
									    if (result === 'True') {
									        question.removeClass('incorrect');
									        ++numberOfCorrect;
									    } else {
									        question.addClass('incorrect');
									        ++numberOfIncorrect;
									    }
									}
							}
						);
					}
				);
			    $('#correct').find('SPAN').html(numberOfCorrect);
			    $('#incorrect').find('SPAN').html(numberOfIncorrect);
			    $('#score').find('SPAN').html(((numberOfCorrect / (numberOfCorrect + numberOfIncorrect)) * 100) + '%');

			    var personName = $('#personName').html();
			    $.ajax(
			        {
			            data: ( { personName: personName, numberOfCorrect: numberOfCorrect, numberOfIncorrect: numberOfIncorrect } ),
			            type: 'POST',
			            url: appUrl + 'Home.mvc/Send',
			            success:
			                function( result ) {
			                    // TODO: Display success message?
			                }
			        }
			    );
			}
		);
	};