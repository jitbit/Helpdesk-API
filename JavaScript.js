//This is a basic example of using Jitbit Helpdesk API with jQuery

//Creates a base-64 encoded Authorization header value
var makeBasicAuthHeader = function(username, password) {
	return "Basic " + btoa(username + ":" + password);
}

//Set's default authorization header for all jQuery AJAX requests
$.ajaxSetup({
	headers: { 'Authorization': makeBasicAuthHeader('username', 'password') },
	crossDomain: true
});

//Gets the list of unanswered tickets for the authenticated user
//Replace "XXXXX" with your helpdesk URL
$.get("https://XXXXX.jitbit.com/helpdesk/api/tickets",
	function(tickets){
		if(tickets.length > 0){
			$.each(tickets, function(index, val) {
				console.log(val.Subject);
			});
		}
	}
);
